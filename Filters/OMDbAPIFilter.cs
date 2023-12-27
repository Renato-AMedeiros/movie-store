namespace renato_movie_store.Filters
{
    public class OMDbAPIFilter
    {
        public string i { get; set; }



        // Parâmetros para busca por ID ou título
        public string Id { get; set; } // i
        public string Title { get; set; } // t
        public string Type { get; set; } // type
        public string Year { get; set; } // y
        public string Plot { get; set; } // plot
        public string ResultDataType { get; set; } // r
        public string Callback { get; set; } // callback
        public string ApiVersion { get; set; } // v

        // Parâmetros para busca por termo de pesquisa
        public string SearchTerm { get; set; } // s
        public string SearchType { get; set; } // type
        public string SearchYear { get; set; } // y
        public string SearchResultDataType { get; set; } // r
        public int Page { get; set; } // page
        public string SearchCallback { get; set; } // callback
        public string SearchApiVersion { get; set; } // v

    }
}
