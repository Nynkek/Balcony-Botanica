namespace MyTestProject;

public abstract class Builder<T> where T : class
{
    public abstract T Build();
    public static implicit operator T(Builder<T> builder) => builder.Build();
}
