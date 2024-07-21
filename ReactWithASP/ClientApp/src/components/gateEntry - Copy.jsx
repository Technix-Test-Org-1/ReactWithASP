import { React, useEffect, useState } from 'react';
import './App.css';
import TableWithInputs from './create';
import { Button } from '@progress/kendo-react-buttons';
import { Dialog } from '@progress/kendo-react-dialogs';
import '@progress/kendo-theme-default/dist/all.css';
import { Grid, GridColumn as Column } from '@progress/kendo-react-grid';
const depot = {
    timeZone: { offset: 13, minutes: 780 },
    model: {}
}
function App() {

    const [visibleDialog, setVisibleDialog] = useState(false);
    const toggleDialog = () => {
        setVisibleDialog(!visibleDialog);
    };
    const [users, setUsers] = useState([]);
    useEffect(() => {
        fetch("http://localhost:2190/api/v1/gateEntry/gateEntries?depotId=22844&pageIndex=1&pageSize=20&sortField=1&sortOrder=true")
            .then((response) => response.json())
            .then(
                data => { setUsers(data.Items) });
    }, []);
}
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
    debugger;
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
function getCurrentDateTime() {
    var dt = new Date();
    //if (depot.timeZone.offset !== 0) {
    var diffInTimeZone = depot.timeZone.minutes + dt.getTimezoneOffset();
    dt = new Date(dt.getTime() + diffInTimeZone * 60 * 1000);
    //}
    return dt;
}

export class gateEntry extends App {
    render() {
        return (
            <div className="App">
                {/*{visibleDialog && (*/}
                {/*    <Dialog title={"Please confirm"} onClose={toggleDialog}>*/}
                {/*        <TableWithInputs />*/}
                {/*    </Dialog>*/}
                {/*)}*/}
                {/*<h1> Hello World!</h1>*/}
                {/*<Button onClick={toggleDialog}> Create</Button>*/}

                <Grid
                    style={{
                        height: "400px",
                    }}
                >
                    <Column field="Event" title="Event" />
                    <Column field="TruckNumber" title="Truck No." />
                    <Column field="TransporterName" title="Transporter Name" />
                    <Column field="GateInTime" title="Truck Gate In Time" />
                    <Column field="GateOutTime" title="Truck Gate Out Time" />
                    <Column field="ReferenceNumber" title="Reference No." />
                    <Column field="EquipmentNumber" title="Equipment No." />
                    <Column field="" title="Dwell Time" cell={({ dataItem }) => <span>{toGetDwellTime(dataItem.GateInTime, dataItem.GateOutTime)}</span>} />
                    <Column field="DriverReferenceNumber" title="Driver ref no." />
                    <Column field="GatePassNumber" title="Gate pass number" />
                    <Column field="EquipmentNumber" title="Created Date" />
                    <Column field="EquipmentNumber" title="Truck In/Truck Out	" />
                </Grid>

            </div>

        );
    }
}