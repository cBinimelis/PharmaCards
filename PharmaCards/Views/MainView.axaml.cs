using Avalonia.Controls;
using Avalonia.Interactivity;
using PharmaCards.Data;
using System;
using System.Collections.Generic;

namespace PharmaCards.Views
{
    public partial class MainView : UserControl
    {
        MedicamentModel medicament = new();
        SqlDataAccess database;
        public MainView()
        {
            InitializeComponent();
            database = new SqlDataAccess();
            try
            {
                LoadMedicament();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void DrawCard(object sender, RoutedEventArgs args)
        {
            startPanel.IsVisible = false;
            startPanel.IsEnabled = false;
            medPanel.IsVisible = true;
            medPanel.IsEnabled = true;
        }

        private async void LoadMedicament()
        {
            Random r = new();
            List<MedicamentModel> med = await database.LoadMedicament();
            int choice = r.Next(0, med.Count);

            medicament = med[choice];
            medName.Text = medicament.Name;
            medDescription.Text = medicament.Description;
            medType.Text = medicament.Type;
            medAction.Text = medicament.Action;
            medMOA.Text = medicament.MOA;
            medAdministration.Text = medicament.Administration;
            medClinicalUse.Text = medicament.ClinicalUse;
            medAdverseEffects.Text = medicament.AdverseEffects;
            if (medicament.SpecialPoints == "empty")
            {
                specialPanel.IsVisible = false;
            }
            else
            {
                medSpecialPoints.Text = medicament.SpecialPoints;
            }
        }

        public void GoBack(object sender, RoutedEventArgs args)
        {
            startPanel.IsVisible = true;
            startPanel.IsEnabled = true;
            medPanel.IsVisible = false;
            medInfo.IsVisible = false;
            btnShow.IsVisible = true;
            btnAgain.IsVisible = false;
        }

        public void ShowInfo(object sender, RoutedEventArgs args)
        {
            medInfo.IsVisible = true;
            btnShow.IsVisible = false;
            btnAgain.IsVisible = true;
        }

        public async void DoItAgain(object sender, RoutedEventArgs args)
        {
            medInfo.IsVisible = false;
            btnShow.IsVisible = true;
            try
            {
                LoadMedicament();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}