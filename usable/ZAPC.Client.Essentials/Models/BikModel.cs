namespace ZAPC.Client.Essentials.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using JetBrains.Annotations;

    public class BikModel
    {
        public BikModel([NotNull] IEnumerable<Bik> biks) => Biks = biks.ToArray();

        public Bik[] Biks { get; set; }
    }
}