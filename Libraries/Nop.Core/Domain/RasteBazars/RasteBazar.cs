using Nop.Core.Domain.Common;
using Nop.Core.Domain.Discounts;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Security;
using Nop.Core.Domain.Seo;
using Nop.Core.Domain.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Domain.RasteBazars
{
    /// <summary>
    /// Represents a rastebazar
    /// </summary>
    public partial class RasteBazar : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the meta title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the meta title
        /// </summary>
        public string MetaTitle { get; set; }

        /// <summary>
        /// Gets or sets the picture identifier
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// Gets or sets the meta keywords
        /// </summary>
        public string MetaKeywords { get; set; }
    }
}
