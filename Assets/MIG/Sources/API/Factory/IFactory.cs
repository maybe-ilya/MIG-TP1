namespace MIG.API
{
    public interface IFactory<T>
    {
        T CreateObject();
    }

    public interface IFactory<TOutput, TInput>
    {
        TOutput CreateObject(TInput input);
    }

    public interface IFactory<TOutput, TInput1, TInput2>
    {
        TOutput CreateObject(TInput1 input1, TInput2 input2);
    }

    public interface IFactory<TOutput, TInput1, TInput2, TInput3>
    {
        TOutput CreateObject(TInput1 input1, TInput2 input2, TInput3 input3);
    }
}
