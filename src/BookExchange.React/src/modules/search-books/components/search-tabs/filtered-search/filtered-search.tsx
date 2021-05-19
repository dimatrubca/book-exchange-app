import React, { useEffect, useState } from "react";
import FormHelperText from "@material-ui/core/FormHelperText";
import FormControl from "@material-ui/core/FormControl";
import Select from "@material-ui/core/Select";

import {
  Button,
  Grid,
  InputLabel,
  MenuItem,
  TextField,
} from "@material-ui/core";
import { Autocomplete } from "@material-ui/lab";
import SearchIcon from "@material-ui/icons/Search";
import { Controller, useForm } from "react-hook-form";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";

import { AuthorsService, BookService, CategoryService } from "services";
import { Author, Category, Book } from "types";

const schema = yup.object().shape({
  title: yup.string(),
  description: yup.string(),
  isbn: yup.string(),
  publisher: yup.string(),
  minPageCount: yup.number(),
  maxPageCount: yup.number().min(yup.ref("minPageCount"), "Invalid value"),
  filterOperator: yup.string(),
});

interface FilteredSearchProps {
  page: number;
  setTotalRecords: React.Dispatch<React.SetStateAction<number>>;
  rowsPerPage: number;
  setBooks: React.Dispatch<React.SetStateAction<Book.Book[] | undefined>>;
}

const FilteredSearch = ({
  page,
  rowsPerPage,
  setTotalRecords,
  setBooks,
}: FilteredSearchProps) => {
  const [authorsOptions, setAuthorsOptions] = useState<Author.Author[]>([]);
  const [categoriesOptions, setCategoriesOptions] = useState<
    Category.Category[]
  >([]);

  const {
    register,
    handleSubmit,
    control,
    formState: { errors },
  } = useForm<Book.SearchFilters>({
    resolver: yupResolver(schema),
  });

  const onSubmit = async (data: Book.SearchFilters) => {
    console.log(data);

    try {
      data.pageSize = rowsPerPage;
      data.pageNumber = 1;
      const result = await BookService.GetBooks(data);
      console.log(result);
      console.log("!!!");
      setTotalRecords(result.totalRecords);
      setBooks(result.data);
    } catch (e) {
      console.log(e);
    }
  };

  useEffect(() => {
    const fetchData = async () => {
      try {
        const authors = await AuthorsService.GetAll();
        const categories = await CategoryService.GetAll();

        console.log("authors", authors);
        console.log("categories", categories);

        setAuthorsOptions(authors);
        setCategoriesOptions(categories);
      } catch (e) {
        console.log(e);
      }
    };

    fetchData();
  }, []);

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <Grid container spacing={3}>
        <Grid item xs={12} sm={3}>
          <TextField
            {...register("title")}
            autoComplete="title"
            name="title"
            variant="outlined"
            label="Title"
            fullWidth
            error={!!errors.title}
            helperText={errors.title?.message}
          />
        </Grid>
        <Grid item xs={12} sm={3}>
          <TextField
            {...register("description")}
            autoComplete="description"
            name="description"
            variant="outlined"
            label="Description"
            fullWidth
            error={!!errors.description}
            helperText={errors.description?.message}
          />
        </Grid>
        <Grid item xs={12} sm={3}>
          <TextField
            {...register("isbn")}
            autoComplete="isbn"
            name="isbn"
            variant="outlined"
            label="ISBN"
            fullWidth
            error={!!errors.isbn}
            helperText={errors.isbn?.message}
          />
        </Grid>
        <Grid item xs={12} sm={3}>
          <TextField
            {...register("publisher")}
            autoComplete="publisher"
            name="publisher"
            variant="outlined"
            label="Publisher"
            fullWidth
            error={!!errors.publisher}
            helperText={errors.publisher?.message}
          />
        </Grid>
        <Grid item xs={12} sm={3}>
          <Controller
            name="authors"
            control={control}
            render={({ field: { onChange }, ...props }) => (
              <Autocomplete
                multiple
                {...props}
                id="book-category"
                options={authorsOptions}
                getOptionLabel={(option: Author.Author) => option.name}
                renderOption={(option) => option.name}
                onChange={(e, data) => onChange(data)}
                filterSelectedOptions
                renderInput={(params) => (
                  <TextField {...params} variant="outlined" label="Author" />
                )}
              />
            )}
          />
        </Grid>
        <Grid item xs={12} sm={3}>
          <Controller
            name="categories"
            control={control}
            render={({ field: { onChange }, ...props }) => (
              <Autocomplete
                multiple
                {...props}
                id="book-author"
                options={categoriesOptions}
                getOptionLabel={(option: Category.Category) => option.label}
                renderOption={(option) => option.label}
                onChange={(e, data) => onChange(data)}
                filterSelectedOptions
                renderInput={(params) => (
                  <TextField {...params} variant="outlined" label="Category" />
                )}
              />
            )}
          />
        </Grid>
        <Grid item xs={12} sm={1}>
          <TextField
            {...register("minPageCount")}
            autoComplete="minPageCount"
            name="minPageCount"
            variant="outlined"
            label="Min"
            fullWidth
            error={!!errors.minPageCount}
            helperText={errors.minPageCount?.message}
          />
        </Grid>
        <Grid item xs={12} sm={1}>
          <TextField
            {...register("maxPageCount")}
            autoComplete="maxPageCount"
            name="maxPageCount"
            variant="outlined"
            label="Max"
            fullWidth
            error={!!errors.maxPageCount}
            helperText={errors.maxPageCount?.message}
          />
        </Grid>
        <Grid item xs={12} sm={2}>
          {/* <Controller control={control}>
            <FormControl variant="outlined" fullWidth>
              <InputLabel id="demo-simple-select-outlined-label">
                Filter Operator
              </InputLabel>
              <Select
                labelId="demo-simple-select-outlined-label"
                id="demo-simple-select-outlined"
                // value={age}
                // onChange={handleChange}
                label="Age"
                {...register("filterOperator")}
              >
                <MenuItem value="">
                  <em>None</em>
                </MenuItem>
                <MenuItem value={10}>And</MenuItem>
                <MenuItem value={20}>Or</MenuItem>
              </Select>
            </FormControl>
          </Controller> */}
          <Controller
            render={({ field, fieldState: { invalid, error } }) => (
              <FormControl variant="outlined" fullWidth>
                <InputLabel id="demo-simple-select-outlined-label">
                  Filter Operator
                </InputLabel>
                <Select {...field}>
                  <MenuItem value={10}>10</MenuItem>
                  <MenuItem value={20}>20</MenuItem>
                </Select>
                {
                  (error = { invalid } && (
                    <FormHelperText id="component-helper-text" error={invalid}>
                      {error?.message}
                    </FormHelperText>
                  ))
                }
              </FormControl>
            )}
            control={control}
            name="filterOperator"
          />
        </Grid>
        <Grid item xs={12} sm={2}>
          <FormControl variant="outlined" fullWidth>
            <InputLabel id="demo-simple-select-outlined-label">
              Sort by
            </InputLabel>
            <Select
              labelId="demo-simple-select-outlined-label"
              id="demo-simple-select-outlined"
              // value={age}
              // onChange={handleChange}
              label="Age"
            >
              <MenuItem value="">
                <em>None</em>
              </MenuItem>
              <MenuItem value={10}>Title</MenuItem>
              <MenuItem value={20}>Publisher</MenuItem>
              <MenuItem value={20}>Author</MenuItem>
            </Select>
          </FormControl>
        </Grid>
        {/* <Grid item xs={12} sm={3}>
        <Autocomplete
          multiple
          id="book-language"
          options={authorsOptions}
          getOptionLabel={(option: Author.Author) => option.name}
          filterSelectedOptions
          renderInput={(params) => (
            <TextField {...params} variant="outlined" label="Language" />
          )}
        />
      </Grid> */}
        <Grid item xs={12}>
          <Button
            variant="contained"
            color="primary"
            endIcon={<SearchIcon />}
            type="submit"
          >
            Advanced Search
          </Button>
        </Grid>
      </Grid>
    </form>
  );
};

const top100Films = [
  { title: "The Shawshank Redemption", year: 1994 },
  { title: "The Godfather", year: 1972 },
  { title: "The Godfather: Part II", year: 1974 },
  { title: "The Dark Knight", year: 2008 },
  { title: "12 Angry Men", year: 1957 },
  { title: "Schindler's List", year: 1993 },
  { title: "Pulp Fiction", year: 1994 },
  { title: "The Lord of the Rings: The Return of the King", year: 2003 },
  { title: "The Good, the Bad and the Ugly", year: 1966 },
  { title: "Fight Club", year: 1999 },
  { title: "The Lord of the Rings: The Fellowship of the Ring", year: 2001 },
  { title: "Star Wars: Episode V - The Empire Strikes Back", year: 1980 },
  { title: "Forrest Gump", year: 1994 },
  { title: "Inception", year: 2010 },
  { title: "The Lord of the Rings: The Two Towers", year: 2002 },
  { title: "One Flew Over the Cuckoo's Nest", year: 1975 },
  { title: "Goodfellas", year: 1990 },
  { title: "The Matrix", year: 1999 },
  { title: "Seven Samurai", year: 1954 },
  { title: "Star Wars: Episode IV - A New Hope", year: 1977 },
  { title: "City of God", year: 2002 },
  { title: "Se7en", year: 1995 },
  { title: "The Silence of the Lambs", year: 1991 },
  { title: "It's a Wonderful Life", year: 1946 },
  { title: "Life Is Beautiful", year: 1997 },
  { title: "The Usual Suspects", year: 1995 },
  { title: "Léon: The Professional", year: 1994 },
  { title: "Spirited Away", year: 2001 },
  { title: "Saving Private Ryan", year: 1998 },
  { title: "Once Upon a Time in the West", year: 1968 },
  { title: "American History X", year: 1998 },
  { title: "Interstellar", year: 2014 },
  { title: "Casablanca", year: 1942 },
  { title: "City Lights", year: 1931 },
  { title: "Psycho", year: 1960 },
  { title: "The Green Mile", year: 1999 },
  { title: "The Intouchables", year: 2011 },
  { title: "Modern Times", year: 1936 },
  { title: "Raiders of the Lost Ark", year: 1981 },
  { title: "Rear Window", year: 1954 },
  { title: "The Pianist", year: 2002 },
  { title: "The Departed", year: 2006 },
  { title: "Terminator 2: Judgment Day", year: 1991 },
  { title: "Back to the Future", year: 1985 },
  { title: "Whiplash", year: 2014 },
  { title: "Gladiator", year: 2000 },
  { title: "Memento", year: 2000 },
  { title: "The Prestige", year: 2006 },
  { title: "The Lion King", year: 1994 },
  { title: "Apocalypse Now", year: 1979 },
  { title: "Alien", year: 1979 },
  { title: "Sunset Boulevard", year: 1950 },
  {
    title:
      "Dr. Strangelove or: How I Learned to Stop Worrying and Love the Bomb",
    year: 1964,
  },
  { title: "The Great Dictator", year: 1940 },
  { title: "Cinema Paradiso", year: 1988 },
  { title: "The Lives of Others", year: 2006 },
  { title: "Grave of the Fireflies", year: 1988 },
  { title: "Paths of Glory", year: 1957 },
  { title: "Django Unchained", year: 2012 },
  { title: "The Shining", year: 1980 },
  { title: "WALL·E", year: 2008 },
  { title: "American Beauty", year: 1999 },
  { title: "The Dark Knight Rises", year: 2012 },
  { title: "Princess Mononoke", year: 1997 },
  { title: "Aliens", year: 1986 },
  { title: "Oldboy", year: 2003 },
  { title: "Once Upon a Time in America", year: 1984 },
  { title: "Witness for the Prosecution", year: 1957 },
  { title: "Das Boot", year: 1981 },
  { title: "Citizen Kane", year: 1941 },
  { title: "North by Northwest", year: 1959 },
  { title: "Vertigo", year: 1958 },
  { title: "Star Wars: Episode VI - Return of the Jedi", year: 1983 },
  { title: "Reservoir Dogs", year: 1992 },
  { title: "Braveheart", year: 1995 },
  { title: "M", year: 1931 },
  { title: "Requiem for a Dream", year: 2000 },
  { title: "Amélie", year: 2001 },
  { title: "A Clockwork Orange", year: 1971 },
  { title: "Like Stars on Earth", year: 2007 },
  { title: "Taxi Driver", year: 1976 },
  { title: "Lawrence of Arabia", year: 1962 },
  { title: "Double Indemnity", year: 1944 },
  { title: "Eternal Sunshine of the Spotless Mind", year: 2004 },
  { title: "Amadeus", year: 1984 },
  { title: "To Kill a Mockingbird", year: 1962 },
  { title: "Toy Story 3", year: 2010 },
  { title: "Logan", year: 2017 },
  { title: "Full Metal Jacket", year: 1987 },
  { title: "Dangal", year: 2016 },
  { title: "The Sting", year: 1973 },
  { title: "2001: A Space Odyssey", year: 1968 },
  { title: "Singin' in the Rain", year: 1952 },
  { title: "Toy Story", year: 1995 },
  { title: "Bicycle Thieves", year: 1948 },
  { title: "The Kid", year: 1921 },
  { title: "Inglourious Basterds", year: 2009 },
  { title: "Snatch", year: 2000 },
  { title: "3 Idiots", year: 2009 },
  { title: "Monty Python and the Holy Grail", year: 1975 },
];

export { FilteredSearch };
