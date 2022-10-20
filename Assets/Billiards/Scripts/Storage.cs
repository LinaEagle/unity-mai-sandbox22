using System;

namespace Billiards
{
    public abstract class Storage
    {
        public abstract void Push(Object obj);
        public abstract Object Pull();
    }
}