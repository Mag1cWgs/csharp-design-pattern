using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDesignPattern.BehavioralDesignPattern._8_Command
{
    public class _1_Command
    {

        // 院领导 => 主程序
        
        void Invoke_Command(string[] args)
        {
            // 初始化Receiver、Invoke和Command
            Receiver r = new Receiver();
            Command c = new ConcreteCommand(r);
            CommandInvoker i = new CommandInvoker(c);

            // 院领导发出命令
            i.ExecuteCommand();
        }


        // 教官，负责调用命令对象执行请求
        public class CommandInvoker
        {
            public Command _command;

            public CommandInvoker(Command command)
            {
                this._command = command;
            }

            // 接收命令后执行
            public void ExecuteCommand() => _command.Action();
        }

        // 命令接收者——学生
        public class Receiver
        {
            public void Run1000Meters() => Console.WriteLine("跑1000米");
        }

        // 命令抽象类
        public abstract class Command
        {
            // 命令应该知道接收者是谁，所以有Receiver这个成员变量
            protected Receiver _receiver;

            public Command(Receiver receiver)
            {
                this._receiver = receiver;
            }

            // 命令执行方法
            public abstract void Action();
        }

        //具体指令
        public class ConcreteCommand : Command
        {
            public ConcreteCommand(Receiver receiver)
                : base(receiver)    { }

            // 调用接收的方法，因为执行命令的是学生
            public override void Action() =>_receiver.Run1000Meters();

        }
    }
}
