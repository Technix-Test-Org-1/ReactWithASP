using System;

namespace ReactWithASP.ViewModels
{
    public class GateEntryInOutResult
    {
        /// <summary>
        /// Gets or sets the depot identifier.
        /// </summary>
        /// <value>
        /// The depot identifier.
        /// </value>
        public int DepotId { get; set; }

        /// <summary>
        /// Gets or sets the truck identifier.
        /// </summary>
        /// <value>
        /// The truck identifier.
        /// </value>
        public int TruckId { get; set; }

        /// <summary>
        /// Gets or sets the event code.
        /// </summary>
        /// <value>
        /// The event code.
        /// </value>
        public string EventCode { get; set; }

        /// <summary>
        /// Gets or sets the event.
        /// </summary>
        /// <value>
        /// The event.
        /// </value>
        public string Event { get; set; }

        /// <summary>
        /// Gets or sets the reference number.
        /// </summary>
        /// <value>
        /// The reference number.
        /// </value>
        public string ReferenceNumber { get; set; }

        /// <summary>
        /// Gets or sets the equipment number.
        /// </summary>
        /// <value>
        /// The equipment number.
        /// </value>
        public string EquipmentNumber { get; set; }

        /// <summary>
        /// Gets or sets the truck number.
        /// </summary>
        /// <value>
        /// The truck number.
        /// </value>
        public string TruckNumber { get; set; }

        /// <summary>
        /// Gets or sets the gate in time.
        /// </summary>
        /// <value>
        /// The gate in time.
        /// </value>
        public DateTime? GateInTime { get; set; }

        /// <summary>
        /// Gets or sets the transporter name.
        /// </summary>
        /// <value>
        /// The transporter name.
        /// </value>
        public string TransporterName { get; set; }

        /// <summary>
        /// Gets or sets the gate out time.
        /// </summary>
        /// <value>
        /// The gate out time.
        /// </value>
        public DateTime? GateOutTime { get; set; }

        /// <summary>
        /// Gets or sets the driver reference number.
        /// </summary>
        /// <value>
        /// The driver reference number.
        /// </value>
        public string DriverReferenceNumber { get; set; }

        /// <summary>
        /// Gets or sets the gate pass number.
        /// </summary>
        /// <value>
        /// The gate pass number.
        /// </value>
        public string GatePassNumber { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        /// <value>
        /// The created on.
        /// </value>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the row count.
        /// </summary>
        /// <value>
        /// The row count.
        /// </value>
        public int RowCount { get; set; }

        /// <summary>
        /// Gets or sets the pickup count.
        /// </summary>
        /// <value>
        /// The pickup count.
        /// </value>
        public int PickupCount { get; set; }
    }
}
