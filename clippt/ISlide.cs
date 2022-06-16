using System.Threading.Tasks;

namespace clippt;
public interface ISlide
{
    int Index { get; }
    Task Execute();
}