namespace ImplementingPrototypePattern;

public interface IMyCloneable<T>
{
    T ShallowCopy();
    T DeepCopy();
}
