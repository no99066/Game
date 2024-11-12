using Model;
using Presenters;
using UnityEngine;
using Views;

namespace Setup
{
    public abstract class Setup<TModel, TView> : MonoBehaviour
        where TModel : Entity where TView : View
    {
        [SerializeField] protected TView View;

        protected TModel Model;
        protected IPresenter Presenter;
        protected IUpdateable Updateable;
    }
}