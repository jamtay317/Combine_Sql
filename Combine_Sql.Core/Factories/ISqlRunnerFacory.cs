namespace Combine_Sql.Core.Factories
{
    public interface ISqlRunnerFacory
    {
        ISqlRunner GetRunner(SqlRunnerType runnerType);
    }
}