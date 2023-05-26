namespace MIG.API
{
    public interface IParameterizedFactory<TOutput, TInput>
    {
        TOutput CreateObject(TInput input);
    }
}
