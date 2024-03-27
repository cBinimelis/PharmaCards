using Avalonia.Controls;
using Avalonia.Interactivity;
using PharmaCards.Library;
using System.Collections.Generic;

namespace PharmaCards.Views
{
    public partial class MainView : UserControl
    {
        MedicamentsModel medicament = new();
        public MainView()
        {
            InitializeComponent();
            LoadMedicament();
        }

        public void DrawCard(object sender, RoutedEventArgs args)
        {
            startPanel.IsVisible = false;
            medPanel.IsVisible = true;
        }

        private void LoadMedicament()
        {
            List<MedicamentsModel> med = SqlDataAccess.LoadMedicament();
            medicament = med[0];
            medName.Text = medicament.Name;
            medDescription.Text = medicament.Description;
            medType.Text = medicament.Type;
            medAction.Text = medicament.Action;
            medMOA.Text = medicament.MOA;
            medAdministration.Text = medicament.Administration;
            medAdverseEffects.Text = medicament.AdverseEffects;
        }

        public void GoBack(object sender, RoutedEventArgs args)
        {
            startPanel.IsVisible = true;
            medPanel.IsVisible = false;
            medInfo.IsVisible = false;
        }

        public void ShowInfo(object sender, RoutedEventArgs args)
        {
            medInfo.IsVisible = true;
        }
    }
}