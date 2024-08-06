using Microsoft.VisualBasic;

namespace ReactWithASP.ViewModels
{
    public class MasterBase
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The   code.</value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The   name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets the name of the code.
        /// </summary>
        /// <value>
        /// The name of the code.
        /// </value>
        public string Codename
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Code))
                {
                    return this.Code + " - " + this.Name;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Gets the name of the code.
        /// </summary>
        /// <value>
        /// The name of the code.
        /// </value>
        public string NameCode
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Code))
                {
                    return this.Code + " - " + this.Name;
                }
                else
                {
                    return this.Name;
                }
            }
        }
    }
}
