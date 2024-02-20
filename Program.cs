using System;

public class Student
{
    private State currentState;

    public Student()
    {
        currentState = new NotEnrolledState();
    }

    public void SetState(State state)
    {
        currentState = state;
    }

    public void EnrollCourse()
    {
        currentState.EnrollCourse(this);
    }

    public void SubmitLabWorks(int count)
    {
        currentState.SubmitLabWorks(this, count);
    }

    public void SubmitCourseProject()
    {
        currentState.SubmitCourseProject(this);
    }

    public void TakeExam()
    {
        currentState.TakeExam(this);
    }

    public void PassCourse()
    {
        Console.WriteLine("Студент прошел курс");
    }

    public void FailCourse()
    {
        Console.WriteLine("Студент провалил курс");
    }
}

public abstract class State
{
    public abstract void EnrollCourse(Student student);
    public abstract void SubmitLabWorks(Student student, int count);
    public abstract void SubmitCourseProject(Student student);
    public abstract void TakeExam(Student student);
}

public class NotEnrolledState : State
{
    public override void EnrollCourse(Student student)
    {
        Console.WriteLine("Студент записывается на курс");
        student.SetState(new LabWorksSubmittedState());
    }

    public override void SubmitLabWorks(Student student, int count)
    {
        Console.WriteLine("Студент должен сначала записаться на курс");
    }

    public override void SubmitCourseProject(Student student)
    {
        Console.WriteLine("Студент должен сначала записаться на курс");
    }

    public override void TakeExam(Student student)
    {
        Console.WriteLine("Студент должен сначала записаться на курс");
    }
}

public class LabWorksSubmittedState : State
{
    public override void EnrollCourse(Student student)
    {
        Console.WriteLine("Студент уже зарегистрирован на курсе");
    }

    public override void SubmitLabWorks(Student student, int count)
    {
        Console.WriteLine("Студент подал заявку" + count + " лабораторные работы");
        if (count >= 3)
        {
            student.SetState(new CourseProjectSubmittedState());
        }
    }

    public override void SubmitCourseProject(Student student)
    {
        Console.WriteLine("Студент должен представить не менее 3 лабораторных работ");
    }

    public override void TakeExam(Student student)
    {
        Console.WriteLine("Студент должен представить не менее 3 лабораторных работ");
    }
}

public class CourseProjectSubmittedState : State
{
    public override void EnrollCourse(Student student)
    {
        Console.WriteLine("Студент уже зарегистрирован на курс");
    }

    public override void SubmitLabWorks(Student student, int count)
    {
        Console.WriteLine("Студент уже представил лабораторные работы");
    }

    public override void SubmitCourseProject(Student student)
    {
        Console.WriteLine("Студент представил курсовой проект");
        student.SetState(new ExamTakenState());
    }

    public override void TakeExam(Student student)
    {
        Console.WriteLine("Сначала студент должен представить курсовой проект");
    }
}

public class ExamTakenState : State
{
    public override void EnrollCourse(Student student)
    {
        Console.WriteLine("Студент уже зарегистрирован на курс");
    }

    public override void SubmitLabWorks(Student student, int count)
    {
        Console.WriteLine("Студент уже представил лабораторные работы");
    }

    public override void SubmitCourseProject(Student student)
    {
        Console.WriteLine("Студент уже представил курсовой проект");
    }

    public override void TakeExam(Student student)
    {
        Console.WriteLine("Студент сдал экзамен");
        student.PassCourse();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Student student = new Student();
        student.EnrollCourse();
        student.SubmitLabWorks(2);
        student.SubmitLabWorks(3);
        student.SubmitCourseProject();
        student.TakeExam();
    }
}
