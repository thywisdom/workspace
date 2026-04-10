
public class Generic<T> {

    T data;

    Generic(T data) {
        this.data = data;
    }

    public void print() {
        System.out.println(data);

    }

    public static void main(String[] args) {
        Generic<Integer> num = new Generic<>(23);
        Generic<String> name = new Generic<>("Suman");

        num.print();
        name.print();
    }
}
