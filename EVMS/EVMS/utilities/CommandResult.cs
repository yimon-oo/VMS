namespace EVMS.utilities
{
    public class CommandResult<TEntity> //: ICommandResult where TEntity : BaseEntity
    {
        public bool Success { get; set; }
        public int ErrorCode { get; set; }

        public List<string> Messages { get; set; }
        public List<TEntity> Result { get; set; }
        public int Id { get; set; }


        public CommandResult()
        {
            Success = false;
            Messages = new List<string>();
            Result = new List<TEntity>();
        }

    }
}
