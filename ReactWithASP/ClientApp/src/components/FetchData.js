/// <reference path="../mymodal.js" />
import React, { Component } from 'react';
import './App.css';
import './main.scss';
import TableWithInputs from './create';
import { Button, Icon } from '@progress/kendo-react-buttons';
import { Dialog } from '@progress/kendo-react-dialogs';
import '@progress/kendo-react-common';
import '@progress/kendo-theme-default/dist/all.css';
import { Pager } from '@progress/kendo-react-data-tools';
import { Grid, GridColumn as Column } from '@progress/kendo-react-grid';
import Popup from './MyModal';
import { ComboBox } from '@progress/kendo-react-dropdowns';
const depot = {
    timeZone: { offset: 13, minutes: 780 },
    model: {}
}
const setVisibleDialog = false;

function toGetCurrentMaxDate(date, noSeconds) {
    let returnDate = null;
    let minutes = 0;
    if (date) {
        returnDate = new Date(date);
        minutes = returnDate.getMinutes();
    }
    else {
        let currentDate = new Date();
        let timeZoneMinutes = depot.timeZone && depot.timeZone.minutes ? depot.timeZone.minutes : 0;
        returnDate = new Date(currentDate.getTime() + currentDate.getTimezoneOffset() * 60000);
        minutes = returnDate.getMinutes() + timeZoneMinutes;
    }
    if (noSeconds) {
        return new Date(returnDate.getFullYear(), returnDate.getMonth(), returnDate.getDate(), returnDate.getHours(), minutes, 0, 0);
    }
    else {
        return new Date(returnDate.getFullYear(), returnDate.getMonth(), returnDate.getDate(), returnDate.getHours(), minutes, returnDate.getSeconds(), returnDate.getMilliseconds());
    }
}
function toGetDwellTime(date1, date2) {
    let toDate = toGetCurrentMaxDate(null, false);
    if (date2) {
        toDate = date2;
    }
    if (date1) {
        let dateTime1 = new Date(date1);
        let dateTime2 = new Date(toDate);
        let milli = dateTime2 - dateTime1;
        let minute = Math.floor(milli / (1000 * 60));
        let hour = Math.floor(minute / 60);
        let str = "";
        str += hour > 0 ? hour + "hr" : "";
        str += minute % 60 > 0 ? " " + minute % 60 + "min" : "";
        return str;
    }
    else {
        return "";
    }
}
export class FetchData extends Component {
  constructor(props) {
    super(props);
      this.state = {
          getEquipmentNumbers: [], forecasts: [], users: [], loading: true, showDialog: false, total: 0, page: 1, pageSize: 20000, isOpen: false 
      };
    }
    togglePopup = () => {
        this.setState((setIsOpen) => ({
            isOpen: !setIsOpen.isOpen,
        }));
    };
    toggleDialog = () => {
        this.setState((prevState) => ({
            showDialog: !prevState.showDialog,
        }));
    };
    handlePageChange = (event) => {
        const newPage = event.page;
        this.setState({ page: newPage }, () => {
            this.fetchData(this.state.page, this.state.pageSize);
        });
    };

    handlePageSizeChange = (event) => {
        const newPageSize = event.pageSize;
        this.setState({ pageSize: newPageSize, page: 1 }, () => {
            this.fetchData(this.state.page, this.state.pageSize);
        });
    };
  componentDidMount() {
      //this.populateWeatherData();
      this.populateData();
      const { page, pageSize } = this.state;
      this.fetchData(page, pageSize);
      //this.setState({ users: this.populateData() })

  }

    static renderForecastsTable(forecasts) {
        forecasts = forecasts.map(function (val) {
            return {
                date: new Date(val.date).toLocaleDateString(),
                temperatureC: val.temperatureC,
                temperatureF: val.temperatureF,
                summary: val.summary,
                id: val.date
            }
        });
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Date</th>
            <th>Temp. (C)</th>
            <th>Temp. (F)</th>
            <th>Summary</th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map(forecast =>
              <tr key={forecast.id}>
                  <td>{forecast.date}</td>
              <td>{forecast.temperatureC}</td>
              <td>{forecast.temperatureF}</td>
              <td>{forecast.summary}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
    }


    render() {
        //users = users.map(function (val) { return val });
        //const users = this.populateData();
        return (
            <div className="truckinScreen" id="GateEntry">
                <div className="FilterPanel">
                    <div className="filter-header d-flex col-11">
                        <div>
                            {/*<button onClick={this.togglePopup}>Filter</button>*/}
                            <Button className="btn btn-create ms-3 px-3" onClick={this.togglePopup}><i icon=""></i> Filter</Button>
                            {this.state.isOpen && (
                                <Popup
                                    content={
                                        <>
                                            <div class="col-lg-12">
                                                <label id="EquipmentLabel" class="d-block mb-2">Equipment Number</label>
                                                <ComboBox
                                                    id="EquipmentNumber"
                                                    class=""
                                                    data={this.state.getEquipmentNumbers} // Your array of objects
                                                    textField="Description" // Field to display in the dropdown list
                                                    valueField="Id" // Field to use as the value when an item is selected
                                                    placeholder="Search/Enter transporter name"
                                                    value={this.state.EquipmentNumber} // Assuming you have a state to store selected value
                                                    onChange={(event) => this.handleEquipmentChange(event)} // Handle selection change
                                                    style={{ width: '100%' }}
                                                />
                                            </div>
                                            <div>
                                                <button className="btn btn-create ms-3 px-3" onClick={(event) => this.handleFilterSearch(event)}>Filter</button>
                                            </div>

                                        </>
                                    }
                                    handleClose={this.togglePopup}
                                />
                            )}
                        </div>
                </div>
                    <div class="ms-auto d-flex align-items-center">
                        {this.state.showDialog && (
                            <Dialog title="Create New" onClose={this.toggleDialog} width={1200} height={700}>
                                <TableWithInputs />
                            </Dialog>
                        )}
                        <Button className="btn btn-create ms-3 px-3" onClick={this.toggleDialog}><i icon="icon-Add_line-icon"></i> Create</Button>

            </div>
    </div >
                <div className="App truckingridpanel">
                
                <Grid
                    className="gateEntryGrid"
                    style={{
                        height: "400px",
                    }}
                        data={this.state.users}
                >
                    <Column field="event" title="Event" />
                    <Column field="truckNumber" title="Truck No." />
                    <Column field="transporterName" title="Transporter Name" />
                    <Column field="gateInTime" title="Truck Gate In Time" />
                    <Column field="gateOutTime" title="Truck Gate Out Time" />
                    <Column field="referenceNumber" title="Reference No." />
                    <Column field="equipmentNumber" title="Equipment No." />
                    <Column field="" title="Dwell Time" cell={({ dataItem }) => <span>{toGetDwellTime(dataItem.gateInTime, dataItem.gateOutTime)}</span>} />
                    <Column field="driverReferenceNumber" title="Driver ref no." />
                    <Column field="gatePassNumber" title="Gate pass number" />
                    <Column field="equipmentNumber" title="Created Date" />
                        <Column field="equipmentNumber" title="Truck In/Truck Out	" />
                    </Grid>
                </div>
            </div>
        );
    }
    async handleEquipmentChange(event) {
    debugger
    const value = event.target.value;
    if (value != null) {
        if (value && value.Id > 0) {
            this.setState({ EquipmentNumber: value })
        }
        else {
            const response1 = await fetch('http://localhost:2190/api/v1/gateEntry/getEquipmentListOfValues?type=GI&searchText=${value}&depotId=22844&page=1&pageSize=10000');
                const data1 = await response1.json();
            this.setState({ getEquipmentNumbers: data1.Items, loading: false });
        }
    }
    else {
        this.setState({ EquipmentNumber: {} })
    }
};
    async handleFilterSearch(event) {
    debugger
    const equipmentNumber = this.state.EquipmentNumber && this.state.EquipmentNumber.Description;
    const response = await fetch(`http://localhost:2190/api/v1/gateEntry/gateEntries?depotId=22844&equipmentNumber=${equipmentNumber}&pageIndex=1&pageSize=20&sortField=1&sortOrder=true`);
    const data = await response.json();
    this.setState({ users: data.Items, loading: false });
};
  async populateWeatherData() {
    const response = await fetch('weatherforecast');
    const data = await response.json();
    this.setState({ forecasts: data, loading: false });
    }
    async fetchData(page, pageSize) {
        this.setState({ loading: true });
        try {
            const response = await fetch('https://localhost:44324/api/GateEntry/GetList?' + new URLSearchParams({
                depotId: 22844,
                pageIndex: page,
                pageSize: pageSize,
            }), {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json'
                }
            });
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            const result = await response.json();
            debugger;
            this.setState({ users: JSON.parse(result.data), total: result.total });
        } catch (error) {
            console.error('There has been a problem with your fetch operation:', error);
        } finally {
            this.setState({ loading: false });
        }
    }
    async populateData() {
        const response1 = await fetch('http://localhost:2190/api/v1/gateEntry/getEquipmentListOfValues?type=GI&searchText=m&depotId=22844&page=1&pageSize=1000');
const data1 = await response1.json();
        this.setState({ getEquipmentNumbers: data1.Items, loading: false });
        //const response = await fetch('/api/gateEntries?depotId=22844&pageIndex=1&pageSize=20&sortField=1&sortOrder=true');
        //const data = await response.json();
        //this.setState({ users: data.Items, loading: false });
        ////const response = await fetch('https://localhost:44324/api/GateEntry/GetList?' + new URLSearchParams({
        ////    depotId: 22844,
        ////    pageIndex: this.state.page,
        ////    pageSize: this.state.pageSize,
        ////}), {
        ////    method: 'GET',
        ////    headers: {
        ////        'Content-Type': 'application/json'
        ////    }
        ////});
        //////const response = await fetch('https://localhost:44324/api/GetList?depotId=22844&pageIndex=1&pageSize=20&sortField=1&sortOrder=true')
        ////const data = await response.json();
        ////this.setState({ users: data.data, total: data.total, loading: false });
    }
} 