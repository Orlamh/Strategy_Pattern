using System.Collections.Generic;
using System.Linq;

namespace CommandPattern
{
    public abstract class Command
    {
        public virtual bool ShouldExecute(Context context) => true;

        public virtual void Execute(Context context)
        {
        }

        public virtual void Rollback(Context context)
        {

        }
    }

    public class CapturePaymentCommand : Command
    {
    }

    public class ProcessOrderCommand : Command
    {
    }

    public class PreProcessCommand : Command
    {
    }

    public partial class ActivateProductCommand : Command
    {
        private readonly IEnumerable<IActivator> _activators;

        public ActivateProductCommand(IEnumerable<IActivator> activators)
        {
            _activators = activators;
        }
        public override void Execute(Context context)
        {
            var activator = _activators.First(a => a.IsMatch(context.PurchasedProduct));
            activator.Activate(context);

            //if (context.PurchasedProduct == ProductType.CreditPack)
            //{
            //    //Do something
            //}

            //if (context.PurchasedProduct == ProductType.Image)
            //{
            //    //Do something
            //}

            //if (context.PurchasedProduct == ProductType.Subscription)
            //{
            //    new SubscriptionProductActivator().Activate(context);
            //}
            //base.Execute(context);
        }

        public override void Rollback(Context context)
        {
            base.Rollback(context);
        }

        public override bool ShouldExecute(Context context)
        {
            return base.ShouldExecute(context);
        }
    }
}