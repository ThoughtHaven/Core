namespace ThoughtHaven.Core.Tests.Fakes
{
    public class FakeDisposable : Disposable
    {
        public int OnDispose_CallCount;
        protected override void OnDispose()
        {
            this.OnDispose_CallCount++;
        }
    }
}