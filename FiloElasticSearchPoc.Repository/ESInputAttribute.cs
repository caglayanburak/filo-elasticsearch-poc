using System;
namespace FiloElasticSearchPoc.Repository
{
    [System.AttributeUsage(System.AttributeTargets.All)]  
    public class BoostAttribute:System.Attribute
    {
        public double? Boost
        {
            get;
            set;
        }
    }
}
