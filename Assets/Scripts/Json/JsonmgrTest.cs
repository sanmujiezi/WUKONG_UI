using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class JsonmgrTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Student student = new Student()
        {
            name = "汤圆",
            id = 1,
            score = new Dictionary<string, int>(){
                {"数学",10},
                {"英语",20},
                {"语文",100}
            }
        };

        Student student1 = new Student("王苑", 2);
        JsonMgr.Instance.SaveData(student, "学生1");
        JsonMgr.Instance.SaveData(student1, "学生2", JsonType.JsonUtility);

        Student student2 = JsonMgr.Instance.LoadData<Student>("学生1");
        Student student3 = JsonMgr.Instance.LoadData<Student>("学生2");
        
        print(student2.name);
        print($"{student3.name} 与 {student3.num}");


    }

    // Update is called once per frame
    void Update()
    {

    }
}


public class Student
{
    public string name;
    public int id;
    public float num = 1.4f;
    public Dictionary<string, int> score;
    public List<ScoreInfo> scoreInfos;

    public Student()
    {

    }
    public Student(string name, int id)
    {
        this.name = name;
        this.id = id;
    }
}

public class ScoreInfo
{
    public string descript;
}