﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Semordnilap.Common;

namespace Semordnilap.View
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public static readonly DependencyProperty DnaCodeProperty =
            DependencyProperty.Register(nameof(DnaCode), typeof(IList<INucleobase>), typeof(TextBox), new PropertyMetadata(null));

        public static readonly DependencyProperty RnaCodeProperty =
            DependencyProperty.Register(nameof(RnaCode), typeof(ISequence<INucleobase>), typeof(TextBox), new PropertyMetadata(null));

        public static readonly DependencyProperty AminoAcidsProperty =
            DependencyProperty.Register(nameof(AminoAcids), typeof(ISequence<IAminoAcid>), typeof(TextBox), new PropertyMetadata(null));

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            DnaCode = new List<INucleobase> {
                new Adenine(), new Thymine(), new Guanine(), new Cytosine(), new Thymine(), new Guanine(),
                new Adenine(), new Thymine(), new Cytosine(), new Thymine(), new Thymine(), new Guanine(),
                new Guanine(), new Cytosine(), new Cytosine(), new Adenine(), new Thymine(), new Cytosine(),
                new Adenine(), new Adenine(), new Thymine() };
            RnaCode = new RNA();
            AminoAcids = new Protein();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //todo: model

        public IList<INucleobase> DnaCode
        {
            get { return (IList<INucleobase>)GetValue(DnaCodeProperty); }
            set { 
                SetValue(DnaCodeProperty, value);
                OnPropertyChanged(nameof(DnaCode));
            }
        }

        public ISequence<INucleobase> RnaCode
        {
            get { return (ISequence<INucleobase>)GetValue(RnaCodeProperty); }
            set
            {
                SetValue(RnaCodeProperty, value);
                OnPropertyChanged(nameof(RnaCode));
            }
        }

        public ISequence<IAminoAcid> AminoAcids
        {
            get { return (ISequence<IAminoAcid>)GetValue(AminoAcidsProperty); }
            set
            {
                SetValue(AminoAcidsProperty, value);
                OnPropertyChanged(nameof(AminoAcids));
            }
        }

        private void TranscribeButton_Click(object sender, RoutedEventArgs e)
        {
            RnaCode = Transkription.ToRna(new DNA(DnaCode));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void TranslateButton_Click(object sender, RoutedEventArgs e)
        {
            AminoAcids = Translation.ToProtein(RnaCode);
        }

        private void LoadFastaFileButton_Click(object sender, RoutedEventArgs e)
        {
            ImportModel import = (ImportModel)((Control)sender).DataContext;

            //TODO: file Validation Rule instead
            bool exists = File.Exists(import.FilePath);
            Debug.Assert(exists);

            using(FileStream inputStream = File.OpenRead(import.FilePath))
            {
                AminoAcids = import.InputSequence.Parse(inputStream).First();
            }

        }
    }


}
