using ETickets.Data.Enums;
using ETickets.Models;

namespace ETickets.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Cinema
                if(!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Cinema 1",
                            Logo = "http://localhost:4200/assets/images/DSCF5957.JPG",
                            Description="Short Cinema 1 Description"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 2",
                            Logo = "http://localhost:4200/assets/images/DSCF5963.JPG",
                            Description="Short Cinema 2 Description"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 3",
                            Logo = "http://localhost:4200/assets/images/DSCF5597.JPG",
                            Description="Short Cinema 3 Description"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 4",
                            Logo = "http://localhost:4200/assets/images/DSCF5613.JPG",
                            Description="Short Cinema 4 Description"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 5",
                            Logo = "http://localhost:4200/assets/images/DSCF6017.JPG",
                            Description="Short Cinema 5 Description"
                        }
                    });
                    context.SaveChanges();
                }

                //Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName="Actor 1",
                            ProfilePictureUrl = "http://localhost:4200/assets/images/DSCF5957.JPG",
                            Bio="Short bio for Actor 1"
                        },
                        new Actor()
                        {
                            FullName="Actor 2",
                            ProfilePictureUrl = "http://localhost:4200/assets/images/DSCF5963.JPG",
                            Bio="Short bio for Actor 2"
                        },
                        new Actor()
                        {
                            FullName="Actor 3",
                            ProfilePictureUrl = "http://localhost:4200/assets/images/DSCF5597.JPG",
                            Bio="Short bio for Actor 3"
                        },
                        new Actor()
                        {
                            FullName="Actor 4",
                            ProfilePictureUrl = "http://localhost:4200/assets/images/DSCF5613.JPG",
                            Bio="Short bio for Actor 4"
                        },
                        new Actor()
                        {
                            FullName="Actor 5",
                            ProfilePictureUrl = "http://localhost:4200/assets/images/DSCF6017.JPG",
                            Bio="Short bio for Actor 5"
                        }
                    });
                    context.SaveChanges();
                }

                //Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName="Producer 1",
                            ProfilePictureUrl = "http://localhost:4200/assets/images/DSCF5957.JPG",
                            Bio = "Short bio for Producer 1"
                        },
                         new Producer()
                        {
                            FullName="Producer 2",
                            ProfilePictureUrl = "http://localhost:4200/assets/images/DSCF5963.JPG",
                            Bio = "Short bio for Producer 2"
                        },
                          new Producer()
                        {
                            FullName="Producer 3",
                            ProfilePictureUrl = "http://localhost:4200/assets/images/DSCF5597.JPG",
                            Bio = "Short bio for Producer 3"
                        },
                           new Producer()
                        {
                            FullName="Producer 4",
                            ProfilePictureUrl = "http://localhost:4200/assets/images/DSCF5613.JPG",
                            Bio = "Short bio for Producer 4"
                        },
                         new Producer()
                        {
                            FullName="Producer 5",
                            ProfilePictureUrl = "http://localhost:4200/assets/images/DSCF6017.JPG",
                            Bio = "Short bio for Producer 5"
                        }
                    });
                    context.SaveChanges();
                }

                //Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name="Movie 1",
                            Description="Short description for Movie 1",
                            Price= 150,
                            ImageUrl = "http://localhost:4200/assets/images/DSCF5957.JPG",
                            StartDate=DateTime.Now,
                            EndDate=DateTime.Now.AddDays(7),
                            CinemaId= 1,
                            ProducerId=1,
                            MovieCategory=MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name="Movie 2",
                            Description="Short description for Movie 2",
                            Price= 150,
                            ImageUrl = "http://localhost:4200/assets/images/DSCF5963.JPG",
                            StartDate=DateTime.Now,
                            EndDate=DateTime.Now.AddDays(7),
                            CinemaId= 2,
                            ProducerId=2,
                            MovieCategory=MovieCategory.Drama
                        },
                        new Movie()
                        {
                            Name="Movie 3",
                            Description="Short description for Movie 3",
                            Price= 150,
                            ImageUrl = "http://localhost:4200/assets/images/DSCF5597.JPG",
                            StartDate=DateTime.Now,
                            EndDate=DateTime.Now.AddDays(7),
                            CinemaId= 3,
                            ProducerId=3,
                            MovieCategory=MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name="Movie 4",
                            Description="Short description for Movie 4",
                            Price= 150,
                            ImageUrl = "http://localhost:4200/assets/images/DSCF5613.JPG",
                            StartDate=DateTime.Now,
                            EndDate=DateTime.Now.AddDays(7),
                            CinemaId= 4,
                            ProducerId=4,
                            MovieCategory=MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name="Movie 5",
                            Description="Short description for Movie 5",
                            Price= 150,
                            ImageUrl = "http://localhost:4200/assets/images/DSCF6017.JPG",
                            StartDate=DateTime.Now,
                            EndDate=DateTime.Now.AddDays(7),
                            CinemaId= 5,
                            ProducerId=5,
                            MovieCategory=MovieCategory.Comedy
                        }
                    });
                    context.SaveChanges();
                }

                //Actors Movies
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId=1,
                            MovieId =1
                        },
                        new Actor_Movie()
                        {
                            ActorId=2,
                            MovieId =1
                        },

                        new Actor_Movie()
                        {
                            ActorId=3,
                            MovieId =2
                        },

                        new Actor_Movie()
                        {
                            ActorId=4,
                            MovieId =2
                        },

                        new Actor_Movie()
                        {
                            ActorId=2,
                            MovieId =3
                        },

                        new Actor_Movie()
                        {
                            ActorId=3,
                            MovieId =3
                        },

                        new Actor_Movie()
                        {
                            ActorId=1,
                            MovieId =4
                        },

                        new Actor_Movie()
                        {
                            ActorId=5,
                            MovieId =4
                        },

                        new Actor_Movie()
                        {
                            ActorId=2,
                            MovieId =5
                        },

                        new Actor_Movie()
                        {
                            ActorId=4,
                            MovieId =5
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
