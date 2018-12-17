using System.Collections.Generic;
using System.Linq;

namespace ZAPC.Client.Essentials.Models
{
    using JetBrains.Annotations;

    public class BikDiffModel
    {
        public BikDiffModel([NotNull] IEnumerable<BikDiff> biks) => Diff = biks.ToArray();

        public BikDiff[] Diff { get; set; }
    }
}
