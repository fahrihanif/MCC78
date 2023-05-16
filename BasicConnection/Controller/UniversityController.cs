using BasicConnection.Model;
using BasicConnection.View;

namespace BasicConnection.Controller;

public class UniversityController
{
    private University _university = new University();
    
    public void GetAll()
    {
        var results = _university.GetUniversities();
        var view = new UniversityView();
        if (results.Count == 0) {
            view.Output("Data Tidak Ditemukan");
        }
        else {
            view.Output(results);
        }
    }
    
    public void GetById(int id)
    {
        /*var result = _university.(id);
        var view = new UniversityView();
        if (result == null) {
            view.Output("Data Tidak Ditemukan");
        }
        else {
            view.Output(result);
        }*/
    }

    public void Insert(University university)
    {
        var result = _university.InsertUniversity(university);
        var view = new UniversityView();
        if (result == 0) {
            view.Output("Sesuatu Salah!");
        }
        else {
            view.Output("Data Berhasil Ditambahkan");
        }
    }
    
}