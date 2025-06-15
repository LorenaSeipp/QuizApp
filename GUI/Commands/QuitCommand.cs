using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Commands
{
    internal class QuitCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            System.Windows.Application.Current.Shutdown();    
        }
    }
}
