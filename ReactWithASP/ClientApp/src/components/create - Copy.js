import React, { useState, useEffect } from 'react';
import PropTypes from 'prop-types';
import { Grid, GridColumn } from '@progress/kendo-react-grid';
import { DatePicker } from '@progress/kendo-react-dateinputs';
import { AutoComplete } from '@progress/kendo-react-dropdowns';
import { RadioButton, Input, TextArea } from '@progress/kendo-react-inputs';
import { ComboBox } from '@progress/kendo-react-dropdowns';


const Table = ({ rowCount }) => {
    const [tableData, setTableData] = useState([]);

    useEffect(() => {
        // Generate initial table data with empty rows based on rowCount
        const initialData = Array.from({ length: rowCount }, (_, index) => ({
            id: index + 1,
            autoCompleteValue: '',
            datePickerValue: new Date(),
            inputValue: '',
            radioButtonValue: 'Option1',
            textAreaValue: '',
            comboBoxValue: ''
        }));
        setTableData(initialData);
    }, [rowCount]);

    const handleInputChange = (event, field, dataItem) => {
        const newData = tableData.map(item =>
            item.id === dataItem.id ? { ...item, [field]: event.target.value } : item
        );
        setTableData(newData);
    };

    const handleDatePickerChange = (event, field, dataItem) => {
        const newData = tableData.map(item =>
            item.id === dataItem.id ? { ...item, [field]: event.value } : item
        );
        setTableData(newData);
    };

    const handleRadioButtonChange = (event, field, dataItem) => {
        const newData = tableData.map(item =>
            item.id === dataItem.id ? { ...item, [field]: event.target.value } : item
        );
        setTableData(newData);
    };
    const [rowCount2, setRowCount] = useState(0);
    const handleNumericInputChange = (event) => {
        const count = parseInt(event.target.value, 10);
        if (!isNaN(count)) {
            setRowCount(count);
            // Generate initial table data with empty rows
            const initialData = Array.from({ length: count }, (_, index) => ({
                id: index + 1, autoCompleteValue: '', datePickerValue: new Date(), inputValue: '', radioButtonValue: 'Option1', textAreaValue: '', comboBoxValue: ''
            }));
            setTableData(initialData);
        } else {
            setRowCount(0);
            setTableData([]);
        }
    };

    return (
        <div>
            <Input
                type="number"
                value={rowCount2}
                onChange={handleNumericInputChange}
                style={{ marginBottom: '20px' }}
            />
            <Grid
                style={{ height: '400px' }}
                data={tableData}
                editField="inEdit"
                onItemChange={(event) => console.log(event)}
            >
                <GridColumn field="id" title="ID" editable={false} />
                <GridColumn
                    field="autoCompleteValue"
                    title="AutoComplete"
                    cell={(props) => (
                        <AutoComplete
                            value={props.dataItem.autoCompleteValue}
                            onChange={(event) => handleInputChange(event, 'autoCompleteValue', props.dataItem)}
                            data={['Option 1', 'Option 2', 'Option 3']}
                        />
                    )}
                />
                <GridColumn
                    field="datePickerValue"
                    title="DatePicker"
                    cell={(props) => (
                        <DatePicker
                            value={props.dataItem.datePickerValue}
                            onChange={(event) => handleDatePickerChange(event, 'datePickerValue', props.dataItem)}
                        />
                    )}
                />
                <GridColumn
                    field="inputValue"
                    title="Input"
                    cell={(props) => (
                        <Input
                            value={props.dataItem.inputValue}
                            onChange={(event) => handleInputChange(event, 'inputValue', props.dataItem)}
                        />
                    )}
                />
                <GridColumn
                    field="radioButtonValue"
                    title="Radio Buttons"
                    cell={(props) => (
                        <div>
                            <RadioButton
                                value="Option1"
                                label="Option 1"
                                checked={props.dataItem.radioButtonValue === 'Option1'}
                                onChange={(event) => handleRadioButtonChange(event, 'radioButtonValue', props.dataItem)}
                            />
                            <RadioButton
                                value="Option2"
                                label="Option 2"
                                checked={props.dataItem.radioButtonValue === 'Option2'}
                                onChange={(event) => handleRadioButtonChange(event, 'radioButtonValue', props.dataItem)}
                            />
                        </div>
                    )}
                />
                <GridColumn
                    field="textAreaValue"
                    title="Text Area"
                    cell={(props) => (
                        <TextArea
                            value={props.dataItem.textAreaValue}
                            onChange={(event) => handleInputChange(event, 'textAreaValue', props.dataItem)}
                        />
                    )}
                />
                <GridColumn
                    field="comboBoxValue"
                    title="Text Area"
                    cell={(props) => (
                        <ComboBox
                            className="Appbtn"
                            data={['ABC', 'DEF', 'GHI']}
                            placeholder="Select an option"
                            value={props.dataItem.comboBoxValue}
                            onChange={(event) => handleInputChange(event, 'comboBoxValue', props.dataItem)}
                        />
                    )}
                />
            </Grid>
        </div>
    );
};

Table.propTypes = {
    rowCount: PropTypes.number.isRequired,
};

export default Table;
