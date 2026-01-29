using _2chiExam.Dtos;
using _2chiExam.Models;

namespace _2chiExam.Services;

public class MovieService : IMovieService
{
    public List<Movie> MovieGetDtos;
    public MovieService()
    {
        MovieGetDtos = new List<Movie>();
    }

    public Guid AddMovie(MovieCreateDto movieCreateDto)
    {
        var GetMovie = new Movie()
        {
            Id = Guid.NewGuid(),
            Title = movieCreateDto.Title,
            Director = movieCreateDto.Director,
            DurationMinutes = movieCreateDto.DurationMinutes,
            Reting = movieCreateDto.Reting,
            BoxOfficeEarnings = movieCreateDto.BoxOfficeEarnings,
            ReleaseDate = DateTime.UtcNow
        };

        MovieGetDtos.Add(GetMovie);
        return GetMovie.Id;
    }

    public bool DeleteMovie(Guid movieId)
    {
        foreach (var movie in MovieGetDtos)
        {
            if (movie.Id == movieId)
            {
                MovieGetDtos.Remove(movie);
                return true;
            }
        }
        return false;
    }

    public List<MovieGetDto> GetAllMovie()
    {
        return ToGetMoviDtos(MovieGetDtos);
    }

    public List<MovieGetDto> GetAllMoviesByDirector(string director)
    {
        var list = new List<MovieGetDto>();

        foreach (var movie in MovieGetDtos)
        {
            if (movie.Director == director)
            {
                list.Add(ToGetMoviDto(movie));

            }
        }
        return list;
    }

    public MovieGetDto GetHighestGrossingMovie()
    {
        var maxMovie = MovieGetDtos[0];

        foreach (var movie in MovieGetDtos)
        {
            if (maxMovie.BoxOfficeEarnings < movie.BoxOfficeEarnings)
            {
                maxMovie = movie;
            }
        }

        return ToGetMoviDto(maxMovie);
    }

    public MovieGetDto? GetMovieById(Guid movieId)
    {
        foreach (var movie in MovieGetDtos)
        {
            if (movie.Id == movieId)
            {
                return ToGetMoviDto(movie);
            }
        }
        return null;
    }

    public List<MovieGetDto> GetMoviesReleasedAfterYear(int year)
    {
        var list = new List<MovieGetDto>();

        foreach (var movie in MovieGetDtos)
        {
            if (movie.ReleaseDate.Year > year)
            {
                list.Add(ToGetMoviDto(movie));
            }
        }
        return list;
    }

    public List<MovieGetDto> GetMoviesWithinDurationRengr(int minMinutes, int maxMinutes)
    {
        var movieDto = new List<MovieGetDto>();

        foreach (var movie in MovieGetDtos)
        {
            if (movie.ReleaseDate.Minute > minMinutes && movie.ReleaseDate.Minute < maxMinutes)
            {
                movieDto.Add(ToGetMoviDto(movie));
            }
        }
        return movieDto;
    }

    public List<MovieGetDto> GetRecentMovies(int years)
    {
        var movies = new List<MovieGetDto>();

        foreach (var movie in MovieGetDtos)
        {
            if (movie.ReleaseDate.Year == years)
            {
                movies.Add(ToGetMoviDto(movie));
            }
        }
        return movies;
    }

    public MovieGetDto GetTopRetedMovie()
    {
        var maxMovie = MovieGetDtos[0];

        foreach (var movie in MovieGetDtos)
        {
            if (maxMovie.Reting < movie.Reting)
            {
                maxMovie = movie;
            }
        }

        return ToGetMoviDto(maxMovie);
    }

    public long GetTotalBoxOfficeEarningsByDirector(string director)
    {
        long sum = 0;

        foreach (var movie in MovieGetDtos)
        {
            if (movie.Director == director)
            {
                sum = movie.BoxOfficeEarnings;
            }
        }

        return sum;
    }

    public List<MovieGetDto> SearchMoviesByTitle(string keyword)
    {
        var movies = new List<MovieGetDto>();

        foreach (var movie in MovieGetDtos)
        {
            if (movie.Title == keyword)
            {
                movies.Add(ToGetMoviDto(movie));

            }
        }
        return movies;
    }

    public bool UpdateMovie(Guid Id, MovieUpdateDto movieUpdateDto)
    {
        foreach (var item in MovieGetDtos)
        {
            if (item.Id == Id)
            {
                item.Director = movieUpdateDto.Director;
                item.Title = movieUpdateDto.Title;
                item.DurationMinutes = movieUpdateDto.DurationMinutes;
                item.Reting = movieUpdateDto.Reting;
                item.BoxOfficeEarnings = movieUpdateDto.BoxOfficeEarnings;
                item.ReleaseDate = movieUpdateDto.ReleaseDate;
                item.Id = movieUpdateDto.Id;
            }
            return true;

        }
        return false;

    }

    public MovieGetDto ToGetMoviDto(Movie movie)
    {
        var GetMovieDto = new MovieGetDto()
        {
            BoxOfficeEarnings = movie.BoxOfficeEarnings,
            Title = movie.Title,
            Director = movie.Director,
            DurationMinutes = movie.DurationMinutes,
            ReleaseDate = movie.ReleaseDate,
            Reting = movie.Reting,
            Id = movie.Id,
        };
        return GetMovieDto;
    }

    public List<MovieGetDto> ToGetMoviDtos(List<Movie> movies)
    {
        var GetList = new List<MovieGetDto>();
        foreach (var movie in movies)
        {
            GetList.Add(ToGetMoviDto(movie));
        }
        return GetList;
    }
}
