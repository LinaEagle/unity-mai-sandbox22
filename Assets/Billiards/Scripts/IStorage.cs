using System;

namespace Billiards
{
    public interface IStorage
    {
        void Push(Object obj);
        Object Pull();
    }
}