public interface FilmInterface {
    FilmDTOResponse AddFilm(FilmDTORequest dTORequest); 
    FilmDTOResponse updateFilm(FilmDTORequest dTORequest);
    FilmDTOResponse deleteFilm(FilmDTORequest dTORequest); 
}