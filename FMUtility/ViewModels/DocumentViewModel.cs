﻿using System;
using System.ComponentModel;
using System.Windows.Input;
using FMUtility.Commands;

namespace FMUtility.ViewModels
{
    public interface IDocumentViewModel : INotifyPropertyChanged
    {
        Guid Id { get;}
        string Title { get;}
        ICommand Close { get; }
    }

    public abstract class DocumentViewModel : ViewModelBase, IDocumentViewModel
    {
        protected DocumentViewModel() : this(true)
        {

        }

        protected DocumentViewModel(bool canClose)
        {
            Id = Guid.NewGuid();
            Close = new CloseDocumentCommand(this, canClose);
        }

        public Guid Id { get; private set; }
        public abstract string Title { get; }
        public ICommand Close { get; private set; }
    }
}
