using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class SecuritySurveillanceHub : IObservable<ExternalVisitor>
    {

        public IDisposable Subscribe(IObserver<ExternalVisitor> observer)
        {

            throw new NotImplementedException();
        }
    }
}
