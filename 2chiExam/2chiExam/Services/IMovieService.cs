using _2chiExam.Dtos;

namespace _2chiExam.Services;

public interface IMovieService
{
    public Guid AddMovie(MovieCreateDto movieCreateDto);
    public bool DeleteMovie(Guid movieId);
    public MovieGetDto? GetMovieById(Guid movieId);
    public List<MovieGetDto> GetAllMovie();
    public bool UpdateMovie(Guid Id, MovieUpdateDto movieCreateDto);
    public List<MovieGetDto> GetAllMoviesByDirector(string  director);
    public MovieGetDto GetTopRetedMovie();
    public List<MovieGetDto> GetMoviesReleasedAfterYear(int year);
    public MovieGetDto GetHighestGrossingMovie();
    public List<MovieGetDto> SearchMoviesByTitle(string keyword);
    public List<MovieGetDto> GetMoviesWithinDurationRengr(int minMinutes, int maxMinutes);
    public long GetTotalBoxOfficeEarningsByDirector(string director);
    public List<MovieGetDto> GetRecentMovies(int years);
    
}