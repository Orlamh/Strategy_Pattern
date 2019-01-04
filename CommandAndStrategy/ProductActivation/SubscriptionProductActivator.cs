using System;

namespace CommandPattern
{

    public partial class ActivateProductCommand
    {
        public class SubscriptionProductActivator :IActivator
        {
            private ProductType ProductType => ProductType.Subscription;
            public void Activate(Context context)
            {
                Console.WriteLine("The Subscription is activated");
            }

            public bool IsMatch(ProductType purchasedType)
            {
                return purchasedType == ProductType;
            }
        }
    }
}