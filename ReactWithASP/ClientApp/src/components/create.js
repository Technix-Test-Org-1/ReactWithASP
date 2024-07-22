import React, { Component } from 'react';
import { Input } from '@progress/kendo-react-inputs';
import { AutoComplete } from '@progress/kendo-react-dropdowns';
import { DatePicker, DateTimePicker } from '@progress/kendo-react-dateinputs';
import { RadioButton } from '@progress/kendo-react-inputs';
import { TextArea, Checkbox } from '@progress/kendo-react-inputs';
import { ComboBox } from '@progress/kendo-react-dropdowns';
import { TabStrip, TabStripTab, TabContent } from '@progress/kendo-react-layout';
import './App.css';


interface TableProps {
    rowCount: number;
}

interface TableState {
    tableData: {
        id: number;
        autoCompleteValue: string;
        datePickerValue: Date;
        inputValue: string;
        radioButtonValue: string;
        textAreaValue: string;
        comboBoxValue: string;
    }[];
    rowCount2: number;
}

export class Table extends Component<TableProps, TableState> {
    constructor(props: TableProps) {
        super(props);

        this.state = {
            tableData: [],
            rowCount2: null,
            getTransportersLov:[],
            getcarriers:[],
            getSizetypes:[],
            getMoveTypes:[],
            getReferences: [],
            selectedTransporterId: null
        };
    }

    componentDidMount() {
        this.generateTableData(this.props.rowCount);
        this.populateLovData();
    }

    componentDidUpdate(prevProps: TableProps) {
        if (this.props.rowCount !== prevProps.rowCount) {
            this.generateTableData(this.props.rowCount);
        }
    }

    generateTableData = (rowCount: number) => {
        const initialData = Array.from({ length: rowCount }, (_, index) => ({
            id: index + 1,
            autoCompleteValue: '',
            datePickerValue: new Date(),
            inputValue: '',
            radioButtonValue: 'Option1',
            textAreaValue: '',
            comboBoxValue: '',
        }));

        this.setState({ tableData: initialData });
    };

    handleInputChange = (event: React.ChangeEvent<HTMLInputElement>, field: string, dataItem: any) => {
        const newData = this.state.tableData.map((item) =>
            item.id === dataItem.id ? { ...item, [field]: event.target.value } : item
        );
        this.setState({ tableData: newData });
    };

    handleDatePickerChange = (event: any, field: string, dataItem: any) => {
        const newData = this.state.tableData.map((item) =>
            item.id === dataItem.id ? { ...item, [field]: event.value } : item
        );
        this.setState({ tableData: newData });
    };

    handleRadioButtonChange = (event: React.ChangeEvent<HTMLInputElement>, field: string, dataItem: any) => {
        const newData = this.state.tableData.map((item) =>
            item.id === dataItem.id ? { ...item, [field]: event.target.value } : item
        );
        this.setState({ tableData: newData });
    };

    handleNumericInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        const count = parseInt(event.target.value, 10);
        if (!isNaN(count)) {
            this.setState({ rowCount2: count });
            this.generateTableData(count);
        } else {
            this.setState({ rowCount2: null, tableData: [] });
        }
    };
    
    render() {

        const { tableData, rowCount2 } = this.state;

        return (
            <div>
                <div class="truckHeadlabel fw-500 mb-2"> Truck Details</div>
                <div class="TruckCreatebg">
                    <div class="d-flex">
                        <div class="flex-grow-1" id="GateEntryCreate" data-category="GateEntryCreate">
                            <div class="row mb-2 lapmb-0">
                                <div class="col-lg-3">
                                    <div className="FilterRadioBox">
                                        <span className="me-3">
                                            <label id="Dropoff" className="mb-1" htmlFor="Dropoff">
                                                Dropoff
                                            </label>
                                            <span className="disabledPanel">
                                                <Checkbox
                                                    id="Dropoff"
                                                    value="D"
                                                    checked={false}
                                                   
                                                />
                                            </span>
                                        </span>
                                        <span>
                                            <label id="PickUp" className="mb-1" htmlFor="pickup">
                                                Pickup
                                            </label>
                                            <span className="disabledPanel">
                                                <Checkbox
                                                    id="pickup"
                                                    value="P"
                                                    checked={false}
                                                    
                                                />
                                            </span>
                                        </span>
                                    </div>
                                </div>
                                <div className="col-lg-3">
                                    <label id="spnTruckNumber" className="d-block mb-2">
                                        Truck No.
                                    </label>
                                    <span className="disabledPanel">
                                        <Input
                                            id="TruckNumber"
                                            type="text"
                                            placeholder="Enter truck no."
                                            style={{ textTransform: 'uppercase' }}
                                        />
                                    </span>
                                </div>
                                <div class="col-lg-3">
                                    <label id="TransporterNameLabel" class="d-block mb-2">Transporter name</label>
                                    <span class="disabledPanel inputonlyfieldtooltip">
                                        <ComboBox
                                            id="TransporterName"
                                            data={this.state.getTransportersLov} // Your array of objects
                                            textField="Name" // Field to display in the dropdown list
                                            valueField="Id" // Field to use as the value when an item is selected
                                            placeholder="Search/Enter transporter name"
                                            value={this.state.selectedTransporterId} // Assuming you have a state to store selected value
                                            onChange={(event) => this.handleTransporterChange(event)} // Handle selection change
                                        />
                                    </span>
                                </div>

</div>
                            <div class="row">
                                <div class="col-lg-3">
                                    <label id="DriverName" class="d-block mb-2">Driver name</label>
                                    <span class="disabledPanel">
                                        <Input class="form-control" id="DriverName" type="text"
                                            placeholder="Enter driver name"
                                            data-bind="value:model.GateEntry.DriverName"/>
                                    </span>
                                </div>
                                <div class="col-lg-3">
                                    <label id="DriverRefNumber" class="d-block mb-2">Driver ref. no.</label>
                                    <span class="disabledPanel">
                                        <Input class="form-control"
                                            id="DriverRefNumber" type="text"
                                            maxlength="50" placeholder="Enter driver ref. no."
                                            data-bind="value:model.GateEntry.DriverReferenceNumber"/>
                                    </span>
                                </div>
                                <div class="col-lg-6">
                                    <div class="row">
                                        <div class="col">
                                            <label id="spnGateInDate" class="d-block mb-2">In date & time</label>
                                            <span class="disabledPanel">
                                                <DateTimePicker
                                                    id="GateInDate" class="bg-white" 
                                                    format="dd/MMM/yyyy HH:mm"
                                                />
                                            </span>
                                        </div>
                                        <div class="col">
                                            <label id="lblGateOutDate" class="d-block mb-2">Out date & time</label>
                                            <span class="disabledPanel">
                                                <DateTimePicker
                                                    id="GateOutDate" class="bg-white" 
                                                    format="dd/MMM/yyyy HH:mm"
                                                />
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>

</div>
                        <div class="TruckIconRight"><i class="icon-Gate-entry"></i></div></div>
                </div>
                <div class="truckHeadlabel fw-500 mb-2 mt-3"> Equipment Details</div>
                <div class="createpoppaneltab">
                    <TabStrip id="depotTabStrip">
                        <TabStripTab
                            selected={true} // Adjust based on active tab logic
                            id="dropOffTab" title={`DROPOFF (0)`}>
                            <TabContent>
                               
                            </TabContent>
                        </TabStripTab>
                    </TabStrip>
                    <div class="d-flex gap-4 mb-2">
                        <div class="col-lg-1">
                            <label class="d-block mb-2" id="spnDropQuantity">Quantity</label>
                            <span class="disabledPanel">
                                <Input type="number" id="DropQuantity" data-format="#" data-placeholder=""
                                    class="w-100" data-min="1" data-max="99" maxlength="2"
                                    onChange={this.handleNumericInputChange} value={rowCount2} />
                            </span>
                        </div>
</div>
                    <div class="">
                        <table class="table border mb-0 table-layout-fixed" style={{ width: '100%', borderCollapse: 'collapse', marginBottom: '20px' }}> 
                        <thead>
                            <tr>
                                    <th></th>
                                    <th>Reference No.</th>
                                    <th>Validity</th>
                                    <th>Carrier</th>
                                    <th>Equipment No.</th>
                                    <th>Size type</th>				
                                    <th>ISO Code</th>
                                    <th>Service type</th>
                                    <th>Move type</th>
                                    <th>Date & time</th>
                                    <th>Grade</th>
                                    <th class="fs-14 text-blue text-end"></th>
                            </tr>
                        </thead>
                        <tbody>
                            {tableData.map((item) => (
                                <tr key={item.id}>
                                    <td>{item.id}</td>
                                    <td>
                                        <span class="disabledPanel gateAutofield inputonlyfieldtooltip">
                                            <AutoComplete
                                                value={item.autoCompleteValue} maxLength="50" data-value-primitive="true" data-filter="contains" data-auto-bind="false" autocomplete="off"
                                                onChange={(event) => this.handleInputChange(event, 'autoCompleteValue', item)}
                                                data={this.state.getReferences}
                                            />
                                        </span>
                                        
                                    </td>
                                    <td>
                                        <span class="disabledPanel validDateGate inputonlyfieldtooltip"><DatePicker
                                            value={item.datePickerValue} id="dropdatepicker#:Id#" placeholder="DD Mmm YYYY" data-format="dd/MMM/yyyy" 
                                            onChange={(event) => this.handleDatePickerChange(event, 'datePickerValue', item)}
                                        /></span>
                                    </td>
                                    <td>
                                        <span class="disabledPanel inputonlyfieldtooltip">
                                            <AutoComplete id="carrierDrop#:Id#"
                                                data-text-field="Name" placeholder="select carrier" data-template="carrierTemplate"
                                                data-value-field="Name" data-value-primitive="false" data-filter="contains" data-auto-bind="false"
                                                data={this.state.getcarriers} autocomplete="off" />
                                        </span>
                                    </td>
                                    <td>
                                        <span class="disabledPanel equipFieldError inputonlyfieldtooltip">
                                            <Input id="dropEquipment#:Id#" class="form-control" type="text"
                                                maxlength="17" placeholder="Enter Equipment No."/>
                                        </span>
                                    {/*    <div>*/}

                                    {/*        <RadioButton*/}
                                    {/*            value="Option1"*/}
                                    {/*            label="Option 1"*/}
                                    {/*            checked={item.radioButtonValue === 'Option1'}*/}
                                    {/*            onChange={(event) => this.handleRadioButtonChange(event, 'radioButtonValue', item)}*/}
                                    {/*        />*/}
                                    {/*        <RadioButton*/}
                                    {/*            value="Option2"*/}
                                    {/*            label="Option 2"*/}
                                    {/*            checked={item.radioButtonValue === 'Option2'}*/}
                                    {/*            onChange={(event) => this.handleRadioButtonChange(event, 'radioButtonValue', item)}*/}
                                    {/*        />*/}
                                    {/*    </div>*/}
                                    </td>
                                    <td>
                                        <span class="disabledPanel inputonlyfieldtooltip">
                                            <ComboBox id="sizetype#:Id#"
                                                data-text-field="SizeType" data-value-field="SizeType" data-filter="contains"
                                                data-value-primitive="false" data-auto-bind="false"
                                                data={this.state.getSizetypes}
                                                class="" data-placeholder="Select sizetype" />
                                        </span>
                                        {/*<TextArea*/}
                                        {/*    value={item.textAreaValue}*/}
                                        {/*    onChange={(event) => this.handleInputChange(event, 'textAreaValue', item)}*/}
                                        {/*/>*/}
                                    </td>
                                    <td>
                                        <span class="disabledPanel inputonlyfieldtooltip">
                                            <ComboBox id="ISOCode#:Id#"
                                                data-placeholder="Select ISO Code"
                                                data-text-field="Code"
                                                data-value-field="Code"
                                                data-filter="contains"
                                                data-auto-bind="false"
                                                data={['ABC', 'DEF', 'GHI']}
                                                class="comboboxdisable w-100" />
                                        </span>
                                        {/*<ComboBox*/}
                                        {/*    placeholder="Select an option"*/}
                                        {/*    value={item.comboBoxValue}*/}
                                        {/*    onChange={(event) => this.handleInputChange(event, 'comboBoxValue', item)}*/}
                                        {/*/>*/}
                                    </td>
                                    <td>
                                        <span class="disabledPanel">
                                            <div class="btn-group btn-group-toggle w-100" data-toggle="buttons" id="ServiceType_#:uid#" >
                                                <label class="btn shadow-none active" id="ServiceTypeEmpty_#:uid#">
                                                    <Input type="radio" class="btn-check" name="options" autocomplete="off" value="E" /> Empty
                                                </label>
                                                <label class="btn shadow-none" id="ServiceTypeFull_#:uid#">
                                                    <Input type="radio" class="btn-check" name="options" autocomplete="off" value="F" /> Full
                                                </label>
                                            </div>
                                        </span>
                                    </td>
                                    <td>
                                        <span class="disabledPanel inputonlyfieldtooltip">
                                            <ComboBox id="dropmovetype#:Id#"
                                                data-text-field="Description" data-value-field="Description" data-template="codeDescriptionTemplate"
                                                data-value-primitive="false" data-auto-bind="false" data-filter="contains"
                                                data={this.state.getMoveTypes}
                                                class="" data-placeholder="Select move type" />
                                        </span>
                                    </td>
                                    <td>
                                        <span class="disabledPanel inputonlyfieldtooltip">
                                            <DateTimePicker class="bg-white" id="dropDatetime#:Id#" 
                                                data-format="dd/MMM/yyyy HH:mm" placeholder="DD MM YYYY HH:MM" />
                                        </span>
                                    </td>
                                    <td>
                                        <span class="disabledPanel inputonlyfieldtooltip">
                                            <ComboBox id="grade#:Id#"
                                                data-text-field="Description" data-value-field="Id" data-filter="contains"
                                                data-value-primitive="false" data-auto-bind="false"
                                                data={this.state.getGrades}
                                                class="" data-placeholder="Select grade" />
                                        </span>
                                    </td>
                                    <td>
                                        <div class="d-flex align-items-center gap-2 Sliderpickbtn">
                                            <i id="moredetailicon" title="More Details" class="icon-more-vert moreinfoicon Editableicon" data-bind="events:{click:events.onMoreDetailsClick}"></i>
                                            <i id="wareslidericon" title="Stack Position" class="icon-depot-stock Editableicon" data-bind="click:stockevents.onStackClick"></i>
                                            <span class="disabledPanel"><i class="icon-Delete_line_icon text-danger" title="Delete" data-bind="events:{click:events.oncontainerDelete}"></i></span>
                                </div>
                                    </td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                </div>
                </div>
                
            </div>
        );
    }
    async populateLovData() {
        debugger;
        const response = await fetch('http://localhost:2190/api/v1/gateEntry/carriers?role=T&depotId=22844');
        const data = await response.json();
        this.setState({ getTransportersLov: data, loading: false });
        const response2 = await fetch('http://localhost:2190/api/v1/gateEntry/getReferences?type=GI&depotId=22844&page=1&pageSize=30&sortField=1&sortType=true');
        const data2 = await response2.json();
        this.setState({ getReferences: data2.Items, loading: false });
    //    const response3 = await fetch('http://localhost:2190/api/v1/gateEntry/getReferences?type=GI&depotId=22844&page=1&pageSize=30&sortField=1&sortType=true');
    //    const data3 = await response.json();
    //    this.setState({ getSizetypes: data2, loading: false });
    }
}

export default Table;
