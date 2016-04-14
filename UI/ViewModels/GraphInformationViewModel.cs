﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using GraphAlgorithms;
using GraphDataLayer;
using UI.Annotations;

namespace UI.ViewModels
{
    public class GraphInformationViewModel : INotifyPropertyChanged
    {
        private double clusteringCoef;
        private List<int[]> cycles;
        private int selectedCycleIndex = -1;
        private IEnumerable<int> selectedCycle;

        public event PropertyChangedEventHandler PropertyChanged;

        public double ClusteringCoefficient
        {
            get { return clusteringCoef; }
            private set
            {
                clusteringCoef = value;
                OnPropertyChanged(nameof(ClusteringCoefficient));
            }
        }

        public List<int[]> Cycles
        {
            get { return cycles; }
            set
            {
                cycles = value;
                OnPropertyChanged(nameof(Cycles));
            }

        }

        public int SelectedCycleIndex
        {
            get { return selectedCycleIndex; }
            set
            {
                selectedCycleIndex = value;
                OnPropertyChanged(nameof(SelectedCycleIndex));
                SelectedCycle = cycles[selectedCycleIndex];
            }
        }

        public IEnumerable<int> SelectedCycle
        {
            get { return selectedCycle; }
            set
            {
                selectedCycle = value;
                OnPropertyChanged(nameof(SelectedCycle));
            }
        }

        public void AnalyzeGraph(IGraph graph)
        {
            if (graph == null)
                return;
            ClusteringCoefficient = graph.ClusteringCoefficient();
            Cycles = graph.FindCycles();
        }


        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}