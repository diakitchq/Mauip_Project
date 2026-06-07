namespace SchoolApp;

public partial class StudentsPage : ContentPage
{
    public StudentsPage()
    {
        InitializeComponent();

        // Mock-данные. На L16 заменим на загрузку из БД.
        StudentsList.ItemsSource = new[]
        {
            "Aida Tulegenova",
            "Bekzat Sarsenov",
            "Dana Iskakova",
            "Erlan Nurpeisov",
            "Madina Akhmetova"
        };
    }

    private async void OnStudentSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not string name) return;

        await Shell.Current.GoToAsync(
            $"{nameof(StudentDetailPage)}?name={Uri.EscapeDataString(name)}");

        // Снимаем выделение, чтобы при возврате тот же студент снова реагировал на тап
        StudentsList.SelectedItem = null;
    }
}