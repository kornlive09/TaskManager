
namespace BL.TaskManagerModule.Pattern.Commands
{
    class AddCommand : Command
    {
        public AddCommand(ITaskManager bl)
        {
            this.Bl = bl;
        }

        public override void Execute()
        {
            
        }

        public override void UnExecute()
        {
            
        }
    }
}
