using Msc.Framework.Common.Model.Pagination;
using System;

namespace ReactWithASP.ViewModels
{
    public class AdvanceSearchRequest : PageRequest
    {
        /// <summary>
        /// Gets or sets the depot identifier.
        /// </summary>
        /// <value>
        /// The depot identifier.
        /// </value>
        public int DepotId { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type value.
        /// </value>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is drop off.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is drop off; otherwise, <c>false</c>.
        /// </value>
        public bool IsDropOff { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is pick up.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is pick up; otherwise, <c>false</c>.
        /// </value>
        public bool IsPickUp { get; set; }

        /// <summary>
        /// Gets or sets the truck number.
        /// </summary>
        /// <value>
        /// The truck number.
        /// </value>
        public string TruckNumber { get; set; }

        /// <summary>
        /// Gets or sets the transporter.
        /// </summary>
        /// <value>
        /// The transporter.
        /// </value>
        public string Transporter { get; set; }

        /// <summary>
        /// Gets or sets from.
        /// </summary>
        /// <value>
        /// From Date value.
        /// </value>
        public DateTime From { get; set; }

        /// <summary>
        /// Gets or sets to.
        /// </summary>
        /// <value>
        /// To Date value.
        /// </value>
        public DateTime To { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the type of the move.
        /// </summary>
        /// <value>
        /// The type of the move.
        /// </value>
        public string MoveType { get; set; }

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
        /// Gets or sets the TruckInOut.
        /// </summary>
        /// <value>
        /// The TruckInOut.
        /// </value>
        public string TruckInOut { get; set; }
    }
}
