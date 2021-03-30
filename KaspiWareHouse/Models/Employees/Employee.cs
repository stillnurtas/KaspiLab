using KaspiWareHouse.Helpers;
using KaspiWareHouse.Interfaces;
using KaspiWareHouse.Models.Products;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspiWareHouse.Models.Employees
{
    public class Employee
    {
        private ConcurrentQueue<ICommand> CommandsQueue;
        public string FullName { get; set; }
        public string Position { get; set; }

        public Employee(string fullName, string position)
        {
            FullName = fullName;
            Position = position;
            CommandsQueue = new ConcurrentQueue<ICommand>();
        }

        public async Task SetCommand(ICommand command)
        {
            await Task.Run(() => {
                CommandsQueue.Enqueue(command);
                command.NotifyOnFinish += MessageHelper.NotifyMessage;
            });
        }

        public async Task ExecuteCommand()
        {
            await Task.Run(() => {
                ICommand commandToExecute;
                CommandsQueue.TryDequeue(out commandToExecute);
                commandToExecute?.Execute();
            });
        }

        public async Task ExecuteAllCommands()
        {
            await Task.Run(() => {
                foreach(var commandToExecute in CommandsQueue)
                {
                    commandToExecute?.Execute();
                }
            });
        }
    }
}
