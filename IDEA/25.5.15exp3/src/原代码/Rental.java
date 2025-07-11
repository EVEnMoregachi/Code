package 原代码;

/**
 * 租赁类
 */
public class Rental {
    private Movie _movie;  // 影片
    private int _daysRented;  // 租期

    public Rental(Movie movie, int daysRented) {
        _movie = movie;
        _daysRented = daysRented;
    }

    public int getDaysRented() {
        return _daysRented;
    }

    public Movie getMovie() {
        return _movie;
    }
}
