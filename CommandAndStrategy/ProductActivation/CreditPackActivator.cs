using System;

namespace CommandPattern
{

    public partial class ActivateProductCommand
    {
        public class CreditPackActivator : IActivator
        {
            private ProductType ProductType => ProductType.CreditPack;
            public void Activate(Context context)
            {
                Console.WriteLine("The CreditPack is activated");
            }

            public bool IsMatch(ProductType purchasedType)
            {
                return purchasedType == ProductType;
            }
        }
    }
}