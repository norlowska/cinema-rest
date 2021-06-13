
using CinemaRest.Service.Enums;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CinemaRest.Service.Models
{
    public class CinemaContext : ICinemaContext
    {
        private IConfigurationRoot ConfigRoot;
        public CinemaContext()
        {
            ConfigRoot = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build(); 
            InitUsers();
            InitMovies();
            InitActors();
            InitCrewMembers();
            InitCharacters();
            InitScreens();
            InitSeats();
            InitScreenings();
            InitReservations();
        }

        /// <summary>
        /// Inicjalizacja listy aktorów
        /// </summary>
        public void InitActors()
        {
            Actors = new List<Actor>();

            Actors.Add(new Actor { Id = new Guid("1e3ea977-fe9d-4532-91b4-13073fdd7bda"), FirstName = "Tomasz", LastName="Kot" });
            Actors.Add(new Actor { Id = new Guid("bb8d6192-5f93-49d1-b99d-ea2579af5e62"), FirstName = "Joanna", LastName="Koroniewska" });
            Actors.Add(new Actor { Id = new Guid("68a320a9-531a-4909-8532-babf63d9f9b9"), FirstName = "Paweł", LastName="Domagała" });
            Actors.Add(new Actor { Id = new Guid("1ad23418-f924-425f-8f53-6b619ebdd442"), FirstName = "Igor", LastName="Kwiatkowski" });
            Actors.Add(new Actor { Id = new Guid("b179ab08-a396-4a61-b679-c20eb5556792"), FirstName = "Danuta", LastName="Błażejczyk" });
            Actors.Add(new Actor { Id = new Guid("7a6d8533-87b0-4478-b1ee-ee5eb0593e5c"), FirstName = "Kinga", LastName="Ilgner" });
            Actors.Add(new Actor { Id = new Guid("c6b3d54e-1c91-4b91-930b-c84880ee44e0"), FirstName = "Krzysztof", LastName="Dracz" });


            Actors.Add(new Actor { Id = new Guid("598170ef-5171-470d-8ae8-aa29d335bb96"), FirstName = "Timothée", LastName = "Chalamet" });
            Actors.Add(new Actor { Id = new Guid("adfd44b6-1365-4a4c-aa48-10b6b334e05c"), FirstName = "Rebecca", LastName = "Ferguson" });
            Actors.Add(new Actor { Id = new Guid("01165fe1-ec30-44ad-8edc-c03a57b0e039"), FirstName = "Oscar", LastName = "Isaac" });
            Actors.Add(new Actor { Id = new Guid("8b4fc0af-88fd-476d-b514-b01982024da5"), FirstName = "Zendaya", SecondName="Maree", LastName = "Stoermer Coleman" });
            Actors.Add(new Actor { Id = new Guid("6ea75e35-5897-4834-b8c6-856ad225ca28"), FirstName = "Stephen", LastName = "McKinley Henderson" });
            Actors.Add(new Actor { Id = new Guid("3b0f1f52-be67-4fc7-88fd-6d590b95af76"), FirstName = "Jason", LastName = "Mamoa" });


            Actors.Add(new Actor { Id = new Guid("13b43c7f-8d7f-4a72-a0e2-dbbaef1d0d3f"), FirstName = "Daniel", LastName = "Craig" });
            Actors.Add(new Actor { Id = new Guid("32226a22-fc80-41d0-a3a8-d36bf5d104e2"), FirstName = "Rami", LastName = "Malek" });
            Actors.Add(new Actor { Id = new Guid("6528795b-004d-41da-813a-925f5d541225"), FirstName = "Léa", LastName = "Seydoux" });
            Actors.Add(new Actor { Id = new Guid("1e731d05-cc7c-479c-9a92-4f75ad01e1b2"), FirstName = "Lashana", LastName = "Lynch" });
            Actors.Add(new Actor { Id = new Guid("7a2175f6-dc0c-4803-99d1-c1a8f1a93f6a"), FirstName = "Ben", LastName = "Whishaw" });
            Actors.Add(new Actor { Id = new Guid("cd096198-2518-4048-aad3-804a3e708de0"), FirstName = "Naomie", LastName = "Harris" });
            Actors.Add(new Actor { Id = new Guid("3df6ec3f-3790-4dc8-98cc-309ffdd31826"), FirstName = "Jeffrey", LastName = "Wright" });


            Actors.Add(new Actor { Id = new Guid("ed00a00c-d356-4a01-8e86-ae957c3ada1d"), FirstName = "Emma", LastName = "Stone" });
            Actors.Add(new Actor { Id = new Guid("869f8c36-b508-4f98-8c94-c466f3569090"), FirstName = "Emma", LastName = "Thompson" });
            Actors.Add(new Actor { Id = new Guid("0eb291fb-e341-4ec4-8886-c6c6fafa9aa5"), FirstName = "Joel", LastName = "Fry" });
            Actors.Add(new Actor { Id = new Guid("08af9a87-4e90-4050-bb0c-ccb89868b1f3"), FirstName = "Paul", SecondName="Walter", LastName = "Hauser" });
            Actors.Add(new Actor { Id = new Guid("b00ee0d2-49ee-44f0-b0fa-efdb73a5dbbb"), FirstName = "Emily", LastName = "Beecham" });
            Actors.Add(new Actor { Id = new Guid("cab8368f-a11b-4339-a498-b65ea55160b1"), FirstName = "Mark", LastName = "Strong" });


            Actors.Add(new Actor { Id = new Guid("7ebc787d-cada-438e-b6e8-bf6ad9dd7960"), FirstName = "Scarlett", LastName = "Johansson" });
            Actors.Add(new Actor { Id = new Guid("ca7b77c9-8bfb-4e25-b644-716e008b2a0f"), FirstName = "Florence", LastName = "Pugh" });
            Actors.Add(new Actor { Id = new Guid("0caaded6-6b9e-439e-8a8e-ab0b1a68530b"), FirstName = "David", LastName = "Harbour" });
            Actors.Add(new Actor { Id = new Guid("bc61f422-5bd4-4e29-b65d-2f87b43a329d"), FirstName = "O-T", LastName="Fagbenle" });
            Actors.Add(new Actor { Id = new Guid("e469b0e4-b841-45c7-a882-1731431c4000"), FirstName = "Rachel", LastName = "Weisz" });
        }

        /// <summary>
        /// Inicjalizacja listy bohaterów
        /// </summary>
        public void InitCharacters()
        {
            Characters = new List<Character>();

            Characters.Add(new Character { Id = new Guid("6dd98d8e-a259-485d-ab47-3cfc276379db"), CharacterName = "Joe Gardner", Actor = Actors.Where(item => item.Id ==new Guid("1e3ea977-fe9d-4532-91b4-13073fdd7bda")).FirstOrDefault(), MovieId=new Guid("c2b5f1fa-976b-4836-b0d6-0ee2d8e4efe0") });
            Characters.Add(new Character { Id = new Guid("656d7ef9-2070-47cf-aec0-3123e2a519ef"), CharacterName = "22", Actor = Actors.Where(item => item.Id ==new Guid("bb8d6192-5f93-49d1-b99d-ea2579af5e62")).FirstOrDefault(), MovieId = new Guid("c2b5f1fa-976b-4836-b0d6-0ee2d8e4efe0") });
            Characters.Add(new Character { Id = new Guid("abb1592a-54d6-4a48-9cf0-3c6c08caecae"), CharacterName = "Tańczyński Wiatrogwiazd", Actor = Actors.Where(item => item.Id ==new Guid("68a320a9-531a-4909-8532-babf63d9f9b9")).FirstOrDefault(), MovieId = new Guid("c2b5f1fa-976b-4836-b0d6-0ee2d8e4efe0") });
            Characters.Add(new Character { Id = new Guid("f66ff844-4ac6-4e90-8cfb-0728a7ed8e5e"), CharacterName = "Dez", Actor = Actors.Where(item => item.Id ==new Guid("1ad23418-f924-425f-8f53-6b619ebdd442")).FirstOrDefault(), MovieId = new Guid("c2b5f1fa-976b-4836-b0d6-0ee2d8e4efe0") });
            Characters.Add(new Character { Id = new Guid("037ed5e8-6e5d-4859-a071-45ab398476e9"), CharacterName = "Dorothea Williams", Actor = Actors.Where(item => item.Id ==new Guid("b179ab08-a396-4a61-b679-c20eb5556792")).FirstOrDefault(), MovieId = new Guid("c2b5f1fa-976b-4836-b0d6-0ee2d8e4efe0") });
            Characters.Add(new Character { Id = new Guid("b3077f8e-6c83-4e3e-b538-f55fa260a760"), CharacterName = "Heniu A", Actor = Actors.Where(item => item.Id ==new Guid("7a6d8533-87b0-4478-b1ee-ee5eb0593e5c")).FirstOrDefault(), MovieId = new Guid("c2b5f1fa-976b-4836-b0d6-0ee2d8e4efe0") });
            Characters.Add(new Character { Id = new Guid("831bfe26-37d3-47c7-88ef-2271f61e8a40"), CharacterName = "Heniu B", Actor = Actors.Where(item => item.Id ==new Guid("c6b3d54e-1c91-4b91-930b-c84880ee44e0")).FirstOrDefault(), MovieId = new Guid("c2b5f1fa-976b-4836-b0d6-0ee2d8e4efe0") });
            Movies.Where(item => item.Id == new Guid("c2b5f1fa-976b-4836-b0d6-0ee2d8e4efe0")).FirstOrDefault().Characters = Characters.Where(item => item.MovieId == new Guid("c2b5f1fa-976b-4836-b0d6-0ee2d8e4efe0")).ToList();


            Characters.Add(new Character { Id = new Guid("85855b50-3d35-4340-acdc-3af851cca843"), CharacterName = "Paul Atryda", Actor = Actors.Where(item => item.Id ==new Guid("598170ef-5171-470d-8ae8-aa29d335bb96")).FirstOrDefault(), MovieId = new Guid("097bba1b-aabc-49dc-a156-bbe8db8f5a6a") });
            Characters.Add(new Character { Id = new Guid("7addd086-53bc-4c15-9ddd-227068b70e32"), CharacterName = "Lady Jessica", Actor = Actors.Where(item => item.Id ==new Guid("adfd44b6-1365-4a4c-aa48-10b6b334e05c")).FirstOrDefault(), MovieId = new Guid("097bba1b-aabc-49dc-a156-bbe8db8f5a6a") });
            Characters.Add(new Character { Id = new Guid("10020472-aecd-4e08-a7e4-2ca47a25d234"), CharacterName = "Książe Leto Atryda", Actor = Actors.Where(item => item.Id ==new Guid("01165fe1-ec30-44ad-8edc-c03a57b0e039")).FirstOrDefault(), MovieId = new Guid("097bba1b-aabc-49dc-a156-bbe8db8f5a6a") });
            Characters.Add(new Character { Id = new Guid("a03ce787-a659-4182-ae20-d60dc52ac83c"), CharacterName = "Chani", Actor = Actors.Where(item => item.Id ==new Guid("8b4fc0af-88fd-476d-b514-b01982024da5")).FirstOrDefault(), MovieId = new Guid("097bba1b-aabc-49dc-a156-bbe8db8f5a6a") });
            Characters.Add(new Character { Id = new Guid("656c05a2-0d63-436d-9fd7-79128609c532"), CharacterName = "Thufir Hawat", Actor = Actors.Where(item => item.Id ==new Guid("6ea75e35-5897-4834-b8c6-856ad225ca28")).FirstOrDefault(), MovieId = new Guid("097bba1b-aabc-49dc-a156-bbe8db8f5a6a") });
            Characters.Add(new Character { Id = new Guid("9b64776b-1f31-4d24-a56e-18cc42c66128"), CharacterName = "Duncan Idaho", Actor = Actors.Where(item => item.Id ==new Guid("3b0f1f52-be67-4fc7-88fd-6d590b95af76")).FirstOrDefault(), MovieId = new Guid("097bba1b-aabc-49dc-a156-bbe8db8f5a6a") });
            Movies.Where(item => item.Id == new Guid("097bba1b-aabc-49dc-a156-bbe8db8f5a6a")).FirstOrDefault().Characters = Characters.Where(item => item.MovieId == new Guid("097bba1b-aabc-49dc-a156-bbe8db8f5a6a")).ToList();


            Characters.Add(new Character { Id = new Guid("2353ec5a-e8e5-436e-a840-79dbf2c64315"), CharacterName = "James Bond", Actor = Actors.Where(item => item.Id ==new Guid("13b43c7f-8d7f-4a72-a0e2-dbbaef1d0d3f")).FirstOrDefault(), MovieId = new Guid("1654edd2-8443-4fa3-9bfb-8686d5d27710") });
            Characters.Add(new Character { Id = new Guid("9207ae46-2639-45d7-a9ef-473f9ddcfa0e"), CharacterName = "Safin", Actor = Actors.Where(item => item.Id ==new Guid("32226a22-fc80-41d0-a3a8-d36bf5d104e2")).FirstOrDefault(), MovieId = new Guid("1654edd2-8443-4fa3-9bfb-8686d5d27710") });
            Characters.Add(new Character { Id = new Guid("416830e3-0aee-480b-a361-fdad48e5fbdf"), CharacterName = "Madeleine Swann", Actor = Actors.Where(item => item.Id ==new Guid("6528795b-004d-41da-813a-925f5d541225")).FirstOrDefault(), MovieId = new Guid("1654edd2-8443-4fa3-9bfb-8686d5d27710") });
            Characters.Add(new Character { Id = new Guid("416830e3-0aee-480b-a361-fdad48e5fbdf"), CharacterName = "Nomi", Actor = Actors.Where(item => item.Id ==new Guid("1e731d05-cc7c-479c-9a92-4f75ad01e1b2")).FirstOrDefault(), MovieId = new Guid("1654edd2-8443-4fa3-9bfb-8686d5d27710") });
            Characters.Add(new Character { Id = new Guid("2d2a8a43-ed0f-479b-a1e3-8b048e8ccd93"), CharacterName = "Q", Actor = Actors.Where(item => item.Id ==new Guid("7a2175f6-dc0c-4803-99d1-c1a8f1a93f6a")).FirstOrDefault(), MovieId = new Guid("1654edd2-8443-4fa3-9bfb-8686d5d27710") });
            Characters.Add(new Character { Id = new Guid("0ff8cd7a-c165-4bf6-8913-7c26ef74401b"), CharacterName = "Eve Moneypenny", Actor = Actors.Where(item => item.Id ==new Guid("cd096198-2518-4048-aad3-804a3e708de0")).FirstOrDefault(), MovieId = new Guid("1654edd2-8443-4fa3-9bfb-8686d5d27710") });
            Characters.Add(new Character { Id = new Guid("cc69c314-01cd-4d15-b85b-43a0b9cd68be"), CharacterName = "Felix Leiter", Actor = Actors.Where(item => item.Id ==new Guid("3df6ec3f-3790-4dc8-98cc-309ffdd31826")).FirstOrDefault(), MovieId = new Guid("1654edd2-8443-4fa3-9bfb-8686d5d27710") });
            Movies.Where(item => item.Id == new Guid("1654edd2-8443-4fa3-9bfb-8686d5d27710")).FirstOrDefault().Characters = Characters.Where(item => item.MovieId == new Guid("1654edd2-8443-4fa3-9bfb-8686d5d27710")).ToList();

            Characters.Add(new Character { Id = new Guid("7dddd791-d285-4fb2-9630-7db93915a5e2"), CharacterName = "Cruella de Vil", Actor = Actors.Where(item => item.Id ==new Guid("ed00a00c-d356-4a01-8e86-ae957c3ada1d")).FirstOrDefault(), MovieId = new Guid("f80a02d4-f806-4723-90a1-4b25c633a818") });
            Characters.Add(new Character { Id = new Guid("6f45d52d-9c2c-48d4-bb3b-8a2e1edd8ee7"), CharacterName = "Baronowa", Actor = Actors.Where(item => item.Id ==new Guid("869f8c36-b508-4f98-8c94-c466f3569090")).FirstOrDefault(), MovieId = new Guid("f80a02d4-f806-4723-90a1-4b25c633a818") });
            Characters.Add(new Character { Id = new Guid("2e7739a8-445c-4faa-b7fe-f40e00daf96b"), CharacterName = "Jasper", Actor = Actors.Where(item => item.Id ==new Guid("0eb291fb-e341-4ec4-8886-c6c6fafa9aa5")).FirstOrDefault(), MovieId = new Guid("f80a02d4-f806-4723-90a1-4b25c633a818") });
            Characters.Add(new Character { Id = new Guid("0e644a3f-3f2c-4bb2-aeab-53734af23da1"), CharacterName = "Horace", Actor = Actors.Where(item => item.Id ==new Guid("08af9a87-4e90-4050-bb0c-ccb89868b1f3")).FirstOrDefault(), MovieId = new Guid("f80a02d4-f806-4723-90a1-4b25c633a818") });
            Characters.Add(new Character { Id = new Guid("b3ab40c6-76f1-42d7-8686-e12efdd7d9a0"), CharacterName = "Anita", Actor = Actors.Where(item => item.Id ==new Guid("b00ee0d2-49ee-44f0-b0fa-efdb73a5dbbb")).FirstOrDefault(), MovieId = new Guid("f80a02d4-f806-4723-90a1-4b25c633a818") });
            Characters.Add(new Character { Id = new Guid("1365887d-dfb0-4e3f-90b4-75df691d8b98"), CharacterName = "Boris", Actor = Actors.Where(item => item.Id ==new Guid("cab8368f-a11b-4339-a498-b65ea55160b1")).FirstOrDefault(), MovieId = new Guid("f80a02d4-f806-4723-90a1-4b25c633a818") });
            Movies.Where(item => item.Id == new Guid("f80a02d4-f806-4723-90a1-4b25c633a818")).FirstOrDefault().Characters = Characters.Where(item => item.MovieId == new Guid("f80a02d4-f806-4723-90a1-4b25c633a818")).ToList();


            Characters.Add(new Character { Id = new Guid("1365887d-dfb0-4e3f-90b4-75df691d8b98"), CharacterName = "Natasha Romanoff / Czarna Wdowa", Actor = Actors.Where(item => item.Id ==new Guid("7ebc787d-cada-438e-b6e8-bf6ad9dd7960")).FirstOrDefault(), MovieId = new Guid("f66f43cb-d5bf-4aa9-9c31-9544320070c8") });
            Characters.Add(new Character { Id = new Guid("1365887d-dfb0-4e3f-90b4-75df691d8b98"), CharacterName = "Yelena Belova", Actor = Actors.Where(item => item.Id ==new Guid("ca7b77c9-8bfb-4e25-b644-716e008b2a0f")).FirstOrDefault(), MovieId = new Guid("f66f43cb-d5bf-4aa9-9c31-9544320070c8") });
            Characters.Add(new Character { Id = new Guid("1365887d-dfb0-4e3f-90b4-75df691d8b98"), CharacterName = "Alexei Shostakov / Red Guardian", Actor = Actors.Where(item => item.Id ==new Guid("0caaded6-6b9e-439e-8a8e-ab0b1a68530b")).FirstOrDefault(), MovieId = new Guid("f66f43cb-d5bf-4aa9-9c31-9544320070c8") });
            Characters.Add(new Character { Id = new Guid("1365887d-dfb0-4e3f-90b4-75df691d8b98"), CharacterName = "Mason", Actor = Actors.Where(item => item.Id ==new Guid("bc61f422-5bd4-4e29-b65d-2f87b43a329d")).FirstOrDefault(), MovieId = new Guid("f66f43cb-d5bf-4aa9-9c31-9544320070c8") });
            Characters.Add(new Character { Id = new Guid("1365887d-dfb0-4e3f-90b4-75df691d8b98"), CharacterName = "Melina Vostokoff", Actor = Actors.Where(item => item.Id ==new Guid("e469b0e4-b841-45c7-a882-1731431c4000")).FirstOrDefault(), MovieId = new Guid("f66f43cb-d5bf-4aa9-9c31-9544320070c8") });
            Movies.Where(item => item.Id == new Guid("f66f43cb-d5bf-4aa9-9c31-9544320070c8")).FirstOrDefault().Characters = Characters.Where(item => item.MovieId == new Guid("f66f43cb-d5bf-4aa9-9c31-9544320070c8")).ToList();

        }

        /// <summary>
        /// Inicjalizacja listy członków ekipy filmowej
        /// </summary>
        public void InitCrewMembers()
        {
            CrewMembers = new List<CrewMember>();
            CrewMembers.Add(new CrewMember { Id = new Guid("601d15fc-b08e-4d88-8312-9e46dac5e955"), FirstName = "Pete", LastName = "Docter", Job = CrewMemberJob.DIRECTOR, MovieId= new Guid("c2b5f1fa-976b-4836-b0d6-0ee2d8e4efe0") });
            CrewMembers.Add(new CrewMember { Id = new Guid("3123a2d3-e4cb-4c33-b443-5090fc5c081f"), FirstName = "Kemp", LastName = "Powers", Job = CrewMemberJob.DIRECTOR, MovieId= new Guid("c2b5f1fa-976b-4836-b0d6-0ee2d8e4efe0") });
            Movies.Where(item => item.Id == new Guid("c2b5f1fa-976b-4836-b0d6-0ee2d8e4efe0")).FirstOrDefault().Crew = CrewMembers.Where(item => item.MovieId == new Guid("c2b5f1fa-976b-4836-b0d6-0ee2d8e4efe0")).ToList();
                
            CrewMembers.Add(new CrewMember { Id = new Guid("f61d70d9-bf3a-4226-9e05-5b3026339e1f"), FirstName = "Denis", LastName = "Villeneuve", Job = CrewMemberJob.DIRECTOR, MovieId = new Guid("097bba1b-aabc-49dc-a156-bbe8db8f5a6a") });
            CrewMembers.Add(new CrewMember { Id = new Guid("48e99268-f27b-4f18-9de7-2b72bb047f18"), FirstName = "Frank", LastName = "Herbert", Job = CrewMemberJob.WRITER, MovieId = new Guid("097bba1b-aabc-49dc-a156-bbe8db8f5a6a") });
            CrewMembers.Add(new CrewMember { Id = new Guid("e2ffe30f-5b89-445c-9922-3bbebeaac18e"), FirstName = "John", LastName = "Spaihts", Job = CrewMemberJob.WRITER, MovieId = new Guid("097bba1b-aabc-49dc-a156-bbe8db8f5a6a") });
            CrewMembers.Add(new CrewMember { Id = new Guid("0a5620c6-dc71-48e8-8f33-b62776dcd8c9"), FirstName = "Eric", LastName = "Roth", Job = CrewMemberJob.WRITER, MovieId = new Guid("097bba1b-aabc-49dc-a156-bbe8db8f5a6a") });
            Movies.Where(item => item.Id == new Guid("097bba1b-aabc-49dc-a156-bbe8db8f5a6a")).FirstOrDefault().Crew = CrewMembers.Where(item => item.MovieId == new Guid("097bba1b-aabc-49dc-a156-bbe8db8f5a6a")).ToList();


            CrewMembers.Add(new CrewMember { Id = new Guid("b37cb5db-7fa7-48a4-86c6-f0c6a423f59f"), FirstName = "Cary", SecondName="Joji", LastName = "Fukunaga", Job = CrewMemberJob.DIRECTOR, MovieId = new Guid("1654edd2-8443-4fa3-9bfb-8686d5d27710") });
            CrewMembers.Add(new CrewMember { Id = new Guid("4c76eba8-a8d4-4f33-aa56-7b490d5b0887"), FirstName = "Neal", LastName = "Purvis", Job = CrewMemberJob.WRITER, MovieId = new Guid("1654edd2-8443-4fa3-9bfb-8686d5d27710") });
            CrewMembers.Add(new CrewMember { Id = new Guid("2bbd8fdd-7c35-4943-b65b-b918d6f97c32"), FirstName = "Robert", LastName = "Wade", Job = CrewMemberJob.WRITER, MovieId = new Guid("1654edd2-8443-4fa3-9bfb-8686d5d27710") });
            CrewMembers.Add(new CrewMember { Id = new Guid("f391d31d-e861-4a76-a57e-30527b79e86c"), FirstName = "Phoebe", LastName = "Waller-Bridge", Job = CrewMemberJob.WRITER, MovieId = new Guid("1654edd2-8443-4fa3-9bfb-8686d5d27710") });
            Movies.Where(item => item.Id == new Guid("1654edd2-8443-4fa3-9bfb-8686d5d27710")).FirstOrDefault().Crew = CrewMembers.Where(item => item.MovieId == new Guid("1654edd2-8443-4fa3-9bfb-8686d5d27710")).ToList();


            CrewMembers.Add(new CrewMember { Id = new Guid("004825a6-1101-42b7-8739-ae533f60d580"), FirstName = "Craig", LastName = "Gillespie", Job = CrewMemberJob.DIRECTOR, MovieId = new Guid("f80a02d4-f806-4723-90a1-4b25c633a818") });
            CrewMembers.Add(new CrewMember { Id = new Guid("ee759312-b5a8-4834-a6fe-87f692d4889b"), FirstName = "Dana", LastName = "Fox", Job = CrewMemberJob.WRITER, MovieId = new Guid("f80a02d4-f806-4723-90a1-4b25c633a818") });
            CrewMembers.Add(new CrewMember { Id = new Guid("8e06e700-f4d8-475a-99af-7ea72c96a1b1"), FirstName = "Tony", LastName = "McNamara", Job = CrewMemberJob.WRITER, MovieId = new Guid("f80a02d4-f806-4723-90a1-4b25c633a818") });
            Movies.Where(item => item.Id == new Guid("f80a02d4-f806-4723-90a1-4b25c633a818")).FirstOrDefault().Crew = CrewMembers.Where(item => item.MovieId == new Guid("f80a02d4-f806-4723-90a1-4b25c633a818")).ToList();


            CrewMembers.Add(new CrewMember { Id = new Guid("fc72efc7-f322-418b-a346-dd44cdf51550"), FirstName = "Cate", LastName = "Shortland", Job = CrewMemberJob.DIRECTOR, MovieId = new Guid("f66f43cb-d5bf-4aa9-9c31-9544320070c8") });
            CrewMembers.Add(new CrewMember { Id = new Guid("7ffe4504-190c-45e5-acce-bbba6bd8befe"), FirstName = "Jac", LastName = "Schaeffer", Job = CrewMemberJob.WRITER, MovieId = new Guid("f66f43cb-d5bf-4aa9-9c31-9544320070c8") });
            CrewMembers.Add(new CrewMember { Id = new Guid("b3f4e2fc-0255-4d0a-aa4b-d0ef132c344c"), FirstName = "Ned", LastName = "Benson", Job = CrewMemberJob.WRITER, MovieId = new Guid("f66f43cb-d5bf-4aa9-9c31-9544320070c8") });
            Movies.Where(item => item.Id == new Guid("f66f43cb-d5bf-4aa9-9c31-9544320070c8")).FirstOrDefault().Crew = CrewMembers.Where(item => item.MovieId == new Guid("f66f43cb-d5bf-4aa9-9c31-9544320070c8")).ToList();
        }

        /// <summary>
        /// Inicjalizacja listy filmów
        /// </summary>
        private void InitMovies()
        {
            string dataDirectory = ConfigRoot.GetSection("AppDataPath").Value;
            Movies = new List<Movie>();
            Movies.Add(new Movie { Id=new Guid("c2b5f1fa-976b-4836-b0d6-0ee2d8e4efe0"), Title = "Co w duszy gra", Description = "Joe Gardner prowadzi zespół muzyczny w gimnazjum. Jego prawdziwą pasją jest jednak jazz. Joe przeżywa kryzys - zaczyna zadawać sobie pytania: \"Po co tu jestem? Jaki jest cel mojego życia?\".", ImageData=File.ReadAllBytes(dataDirectory + "/posters/7934792.3.jpg") });
            Movies.Add(new Movie { Id=new Guid("097bba1b-aabc-49dc-a156-bbe8db8f5a6a"), Title = "Diuna", Description = "Ekranizacja bestsellerowej powieści Franka Herberta. Bardzo odległa przyszłość. Pustynna planeta Arrakis, zwana także Diuną, jest jedynym miejscem we wszechświecie skąd wydobywa się melanż - cenną substancję, która nie tylko przedłuża życie, ale również pozwala na podróże międzygwiezdne i zaglądanie w przyszłość. Z rozkazu imperatora Shaddama IV Diuna zostaje oddana w lenno szlachetnemu rodowi Atrydów. Na Arrakis przybywa książę Leto Atryda, lady Jessika oraz ich syn, Paul. Nikczemny ród Harkonnenów nie zamierza jednak oddać tak łatwo planety swoim wrogom. Bo kto włada Diuną, ten włada całym wszechświatem.", ImageData=File.ReadAllBytes(dataDirectory + "/posters/dune-plakat_c0950a4f56.jpg") });
            Movies.Add(new Movie { Id=new Guid("1654edd2-8443-4fa3-9bfb-8686d5d27710"), Title = "Nie czas umierać", Description = "James Bond opuszcza czynną służbę i cieszy się spokojnym życiem na Jamajce. Tymczasem jednak jego stary przyjaciel Felix Leiter z CIA zwraca się do niego o pomoc. Misja uratowania porwanego naukowca okazuje się o wiele bardziej zdradliwa, niż mogłoby się wydawać i naprowadza agenta 007 na ślad tajemniczego złoczyńcy, dysponującego nową, niezwykle niebezpieczną technologią.", ImageData=File.ReadAllBytes(dataDirectory + "/posters/483299.jpg") });
            Movies.Add(new Movie { Id=new Guid("f80a02d4-f806-4723-90a1-4b25c633a818"), Title = "Cruella", Description = "Film opowiada o buntowniczych początkach jednego z najbardziej znanych i modnych kinowych złoczyńców, legendarnej Cruelli de Mon. Akcja \"Cruelli\" rozgrywa się w Londynie w latach 70. w trakcie punkrockowej rewolucji, opowiada historię Estelli, bystrej i kreatywnej dziewczyny, zdeterminowanej, by zyskać sławę dzięki swoim projektom. Zaprzyjaźnia się z parą młodych złodziei i razem żyją na londyńskich ulicach. Pewnego dnia talent Estelli do mody przyciąga wzrok baronowej von Hellman, legendy mody, granej przez dwukrotną zdobywczynię Oscara Emmę Thompson (\"Howards End\", \"Rozważna i romantyczna\"). Ich relacja wprawia w ruch bieg wydarzeń, które sprawią, że Estella przejdzie na nikczemną stronę i stanie się żądną zemsty Cruellą.", ImageData=File.ReadAllBytes(dataDirectory + "/posters/7946711.3.jpg") });
            Movies.Add(new Movie { Id = new Guid("f66f43cb-d5bf-4aa9-9c31-9544320070c8"), Title = "Czarna Wdowa", Description = "W wyniku niebezpiecznego spisku i podejrzanych powiązań sprzed czasów drużyny Avengers, Natasha Romanoff aka Czarna Wdowa musi skonfrontować się z mrocznymi echami swojej przeszłości. Bohaterka stawia czoła groźnemu, potężnemu przeciwnikowi, który nie cofnie się przed niczym, by ją zniszczyć.", ImageData=File.ReadAllBytes(dataDirectory + "/posters/7915758.3.jpg") });
        }

        /// <summary>
        /// Inicjalizacja listy rezerwacji
        /// </summary>
        private void InitReservations()
        {
            Reservations = new List<Reservation>();
        }

        /// <summary>
        /// Inicjalizacja listy pokazów filmów
        /// </summary>
        private void InitScreenings()
        {
            Screenings = new List<Screening>();
            DateTime today = DateTime.Today;
            #region "Co w duszy gra"
            Screenings.Add(new Screening(new Guid("8a4b86e4-acc9-476f-bae4-a58038791ed6"), new DateTime(today.Year, today.Month, today.Day, 12, 00, 00), Movies.Where(item => item.Id == new Guid("c2b5f1fa-976b-4836-b0d6-0ee2d8e4efe0")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("40bf5176-ebac-4b14-aaf8-da474480e432")).FirstOrDefault()));
            Screenings.Add(new Screening(new Guid("dae8591e-ecd7-4a3b-b9d2-76c17cc2042a"), new DateTime(today.Year, today.Month, today.Day, 15, 45, 00), Movies.Where(item => item.Id == new Guid("c2b5f1fa-976b-4836-b0d6-0ee2d8e4efe0")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("40bf5176-ebac-4b14-aaf8-da474480e432")).FirstOrDefault()));
            Screenings.Add(new Screening(new Guid("bd54a687-65b7-460a-acef-1431960f1e78"), new DateTime(today.Year, today.Month, today.Day, 20, 00, 00), Movies.Where(item => item.Id == new Guid("c2b5f1fa-976b-4836-b0d6-0ee2d8e4efe0")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("40bf5176-ebac-4b14-aaf8-da474480e432")).FirstOrDefault()));

            Screenings.Add(new Screening(new Guid("aca6edd2-85d3-4673-af10-4007fb749e9f"), new DateTime(today.Year, today.Month, today.Day+1, 12, 00, 00), Movies.Where(item => item.Id == new Guid("c2b5f1fa-976b-4836-b0d6-0ee2d8e4efe0")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("40bf5176-ebac-4b14-aaf8-da474480e432")).FirstOrDefault()));
            Screenings.Add(new Screening(new Guid("c486acd6-c62f-495e-b726-bd3acc8ccbaa"), new DateTime(today.Year, today.Month, today.Day+1, 21, 00, 00), Movies.Where(item => item.Id == new Guid("c2b5f1fa-976b-4836-b0d6-0ee2d8e4efe0")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("6bb909d4-57a4-48a3-b067-65edbe64ad3d")).FirstOrDefault()));
            Screenings.Add(new Screening(new Guid("0cc4d40c-71d9-4f5a-a75a-b8230735689f"), new DateTime(today.Year, today.Month, today.Day+1, 14, 40, 00), Movies.Where(item => item.Id == new Guid("c2b5f1fa-976b-4836-b0d6-0ee2d8e4efe0")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("40bf5176-ebac-4b14-aaf8-da474480e432")).FirstOrDefault()));
            Screenings.Add(new Screening(new Guid("db57ec8e-5259-496f-91c1-b560bdb757d6"), new DateTime(today.Year, today.Month, today.Day+1, 20, 00, 00), Movies.Where(item => item.Id == new Guid("c2b5f1fa-976b-4836-b0d6-0ee2d8e4efe0")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("40bf5176-ebac-4b14-aaf8-da474480e432")).FirstOrDefault()));

            Screenings.Add(new Screening(new Guid("b19a13b4-192e-4237-8dc9-f82b8002be81"), new DateTime(today.Year, today.Month, today.Day+2, 12, 00, 00), Movies.Where(item => item.Id == new Guid("c2b5f1fa-976b-4836-b0d6-0ee2d8e4efe0")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("40bf5176-ebac-4b14-aaf8-da474480e432")).FirstOrDefault()));
            Screenings.Add(new Screening(new Guid("a6ed14d4-ddd8-4a4b-a73c-547470ef134d"), new DateTime(today.Year, today.Month, today.Day+3, 12, 00, 00), Movies.Where(item => item.Id == new Guid("c2b5f1fa-976b-4836-b0d6-0ee2d8e4efe0")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("40bf5176-ebac-4b14-aaf8-da474480e432")).FirstOrDefault()));
            #endregion

            #region "Diuna"
            Screenings.Add(new Screening(new Guid("4fbab7c7-eb59-4731-bb40-b32860530d39"), new DateTime(today.Year, today.Month, today.Day, 15, 45, 00), Movies.Where(item => item.Id == new Guid("097bba1b-aabc-49dc-a156-bbe8db8f5a6a")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("694025a3-c7a5-4464-a78a-ce666f19da37")).FirstOrDefault()));
            Screenings.Add(new Screening(new Guid("aafd560f-d000-4445-8103-4e13e249f083"), new DateTime(today.Year, today.Month, today.Day, 12, 00, 00), Movies.Where(item => item.Id == new Guid("097bba1b-aabc-49dc-a156-bbe8db8f5a6a")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("694025a3-c7a5-4464-a78a-ce666f19da37")).FirstOrDefault()));
            Screenings.Add(new Screening(new Guid("5bef6600-8104-4074-a0ee-6400f5da6ed2"), new DateTime(today.Year, today.Month, today.Day, 20, 00, 00), Movies.Where(item => item.Id == new Guid("097bba1b-aabc-49dc-a156-bbe8db8f5a6a")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("694025a3-c7a5-4464-a78a-ce666f19da37")).FirstOrDefault()));
            Screenings.Add(new Screening(new Guid("fb5cff0c-eddb-41a9-85f2-2d9f90b5e5e6"), new DateTime(today.Year, today.Month, today.Day+4, 21, 00, 00), Movies.Where(item => item.Id == new Guid("097bba1b-aabc-49dc-a156-bbe8db8f5a6a")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("40bf5176-ebac-4b14-aaf8-da474480e432")).FirstOrDefault()));

            Screenings.Add(new Screening(new Guid("24ebed85-906c-422d-b20a-657153d6050c"), new DateTime(today.Year, today.Month, today.Day+1, 12, 00, 00), Movies.Where(item => item.Id == new Guid("097bba1b-aabc-49dc-a156-bbe8db8f5a6a")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("694025a3-c7a5-4464-a78a-ce666f19da37")).FirstOrDefault()));
            Screenings.Add(new Screening(new Guid("fb5cff0c-eddb-41a9-85f2-2d9f90b5e5e6"), new DateTime(today.Year, today.Month, today.Day+1, 21, 00, 00), Movies.Where(item => item.Id == new Guid("097bba1b-aabc-49dc-a156-bbe8db8f5a6a")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("40bf5176-ebac-4b14-aaf8-da474480e432")).FirstOrDefault()));
            Screenings.Add(new Screening(new Guid("165fa459-6cda-4034-a043-0d57f4af281b"), new DateTime(today.Year, today.Month, today.Day+1, 14, 40, 00), Movies.Where(item => item.Id == new Guid("097bba1b-aabc-49dc-a156-bbe8db8f5a6a")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("694025a3-c7a5-4464-a78a-ce666f19da37")).FirstOrDefault()));
            Screenings.Add(new Screening(new Guid("2b40fdf7-e4dc-431b-b4ad-aeb5159a2d81"), new DateTime(today.Year, today.Month, today.Day+1, 20, 00, 00), Movies.Where(item => item.Id == new Guid("097bba1b-aabc-49dc-a156-bbe8db8f5a6a")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("694025a3-c7a5-4464-a78a-ce666f19da37")).FirstOrDefault()));

            Screenings.Add(new Screening(new Guid("a26e331a-b1b6-4deb-a258-0334c07f1e8f"), new DateTime(today.Year, today.Month, today.Day+2, 12, 00, 00), Movies.Where(item => item.Id == new Guid("097bba1b-aabc-49dc-a156-bbe8db8f5a6a")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("694025a3-c7a5-4464-a78a-ce666f19da37")).FirstOrDefault()));
            Screenings.Add(new Screening(new Guid("dd60576e-bf60-46f5-b268-fcb8c0e4660d"), new DateTime(today.Year, today.Month, today.Day+3, 12, 00, 00), Movies.Where(item => item.Id == new Guid("097bba1b-aabc-49dc-a156-bbe8db8f5a6a")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("694025a3-c7a5-4464-a78a-ce666f19da37")).FirstOrDefault()));
            #endregion

            #region "Nie czas umierać"
            Screenings.Add(new Screening(new Guid("a54b2b6d-ba61-4c32-a3bb-f2d206cac6a7"), new DateTime(today.Year, today.Month, today.Day, 08, 00, 00), Movies.Where(item => item.Id == new Guid("1654edd2-8443-4fa3-9bfb-8686d5d27710")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("6bb909d4-57a4-48a3-b067-65edbe64ad3d")).FirstOrDefault()));
            Screenings.Add(new Screening(new Guid("6296b64d-889d-4e90-bdce-dde0dc82c298"), new DateTime(today.Year, today.Month, today.Day, 19, 30, 00), Movies.Where(item => item.Id == new Guid("1654edd2-8443-4fa3-9bfb-8686d5d27710")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("694025a3-c7a5-4464-a78a-ce666f19da37")).FirstOrDefault()));

            Screenings.Add(new Screening(new Guid("d64b9278-b33f-4a01-813a-cfba376c7085"), new DateTime(today.Year, today.Month, today.Day+1, 11, 30, 00), Movies.Where(item => item.Id == new Guid("1654edd2-8443-4fa3-9bfb-8686d5d27710")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("40bf5176-ebac-4b14-aaf8-da474480e432")).FirstOrDefault()));
            Screenings.Add(new Screening(new Guid("25259578-b4a5-47b2-b5cc-d8efc4fb09ad"), new DateTime(today.Year, today.Month, today.Day+1, 16, 15, 00), Movies.Where(item => item.Id == new Guid("1654edd2-8443-4fa3-9bfb-8686d5d27710")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("694025a3-c7a5-4464-a78a-ce666f19da37")).FirstOrDefault()));
            Screenings.Add(new Screening(new Guid("92d84288-12ef-41d3-a9c6-e5744a991952"), new DateTime(today.Year, today.Month, today.Day+1, 19, 30, 00), Movies.Where(item => item.Id == new Guid("1654edd2-8443-4fa3-9bfb-8686d5d27710")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("40bf5176-ebac-4b14-aaf8-da474480e432")).FirstOrDefault()));

            Screenings.Add(new Screening(new Guid("96bf3e4e-40ed-41a0-8d43-06403bce1245"), new DateTime(today.Year, today.Month, today.Day+2, 17, 00, 00), Movies.Where(item => item.Id == new Guid("1654edd2-8443-4fa3-9bfb-8686d5d27710")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("694025a3-c7a5-4464-a78a-ce666f19da37")).FirstOrDefault()));
            Screenings.Add(new Screening(new Guid("05c7b8a9-7f38-4de1-9a53-0f923e5a34a4"), new DateTime(today.Year, today.Month, today.Day+2, 19, 30, 00), Movies.Where(item => item.Id == new Guid("1654edd2-8443-4fa3-9bfb-8686d5d27710")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("40bf5176-ebac-4b14-aaf8-da474480e432")).FirstOrDefault()));
            #endregion

            #region "Cruella"
            Screenings.Add(new Screening(new Guid("55d73371-2071-4613-9169-d0cde3fa8b8b"), new DateTime(today.Year, today.Month, today.Day, 08, 00, 00), Movies.Where(item => item.Id == new Guid("f80a02d4-f806-4723-90a1-4b25c633a818")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("6bb909d4-57a4-48a3-b067-65edbe64ad3d")).FirstOrDefault()));
            Screenings.Add(new Screening(new Guid("7a597459-4c1a-4460-afe9-1b7d7b80e9f8"), new DateTime(today.Year, today.Month, today.Day, 19, 30, 00), Movies.Where(item => item.Id == new Guid("f80a02d4-f806-4723-90a1-4b25c633a818")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("694025a3-c7a5-4464-a78a-ce666f19da37")).FirstOrDefault()));
            Screenings.Add(new Screening(new Guid("1c7711f1-d474-4cf9-857e-c49414f7f7fe"), new DateTime(today.Year, today.Month, today.Day+1, 11, 30, 00), Movies.Where(item => item.Id == new Guid("f80a02d4-f806-4723-90a1-4b25c633a818")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("40bf5176-ebac-4b14-aaf8-da474480e432")).FirstOrDefault()));
            Screenings.Add(new Screening(new Guid("34c1cd8f-84dd-4f36-98b4-d0b202bdae31"), new DateTime(today.Year, today.Month, today.Day+1, 16, 15, 00), Movies.Where(item => item.Id == new Guid("f80a02d4-f806-4723-90a1-4b25c633a818")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("694025a3-c7a5-4464-a78a-ce666f19da37")).FirstOrDefault()));
            Screenings.Add(new Screening(new Guid("acc36232-0549-4d7e-9746-33d3869813e9"), new DateTime(today.Year, today.Month, today.Day+1, 19, 30, 00), Movies.Where(item => item.Id == new Guid("f80a02d4-f806-4723-90a1-4b25c633a818")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("40bf5176-ebac-4b14-aaf8-da474480e432")).FirstOrDefault()));

            Screenings.Add(new Screening(new Guid("7d8bf93d-76f4-4974-932a-ac0c7883c7db"), new DateTime(today.Year, today.Month, today.Day+2, 17, 00, 00), Movies.Where(item => item.Id == new Guid("f80a02d4-f806-4723-90a1-4b25c633a818")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("694025a3-c7a5-4464-a78a-ce666f19da37")).FirstOrDefault()));
            Screenings.Add(new Screening(new Guid("0cb76a43-d44c-4689-8dcf-cbbdf50c8d2c"), new DateTime(today.Year, today.Month, today.Day+2, 19, 30, 00), Movies.Where(item => item.Id == new Guid("f80a02d4-f806-4723-90a1-4b25c633a818")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("40bf5176-ebac-4b14-aaf8-da474480e432")).FirstOrDefault()));
            #endregion

            #region "Czarna Wdowa"
            Screenings.Add(new Screening(new Guid("2ff2e221-69be-4628-9b28-144d965ef147"), new DateTime(today.Year, today.Month, today.Day, 08, 00, 00), Movies.Where(item => item.Id == new Guid("f66f43cb-d5bf-4aa9-9c31-9544320070c8")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("6bb909d4-57a4-48a3-b067-65edbe64ad3d")).FirstOrDefault()));
            Screenings.Add(new Screening(new Guid("703b458f-afd1-46bf-bd49-004c4429314b"), new DateTime(today.Year, today.Month, today.Day, 19, 30, 00), Movies.Where(item => item.Id == new Guid("f66f43cb-d5bf-4aa9-9c31-9544320070c8")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("694025a3-c7a5-4464-a78a-ce666f19da37")).FirstOrDefault()));

            Screenings.Add(new Screening(new Guid("27666fd8-93fd-4465-aab0-456476b657e5"), new DateTime(today.Year, today.Month, today.Day+1, 11, 30, 00), Movies.Where(item => item.Id == new Guid("f66f43cb-d5bf-4aa9-9c31-9544320070c8")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("40bf5176-ebac-4b14-aaf8-da474480e432")).FirstOrDefault()));
            Screenings.Add(new Screening(new Guid("b3162fb0-1d43-4381-87dd-55e6ad9d02e4"), new DateTime(today.Year, today.Month, today.Day+1, 16, 15, 00), Movies.Where(item => item.Id == new Guid("f66f43cb-d5bf-4aa9-9c31-9544320070c8")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("694025a3-c7a5-4464-a78a-ce666f19da37")).FirstOrDefault()));
            Screenings.Add(new Screening(new Guid("2465cf5f-6d9f-4469-be8f-033369ca6fc6"), new DateTime(today.Year, today.Month, today.Day+1, 19, 30, 00), Movies.Where(item => item.Id == new Guid("f66f43cb-d5bf-4aa9-9c31-9544320070c8")).FirstOrDefault(), Screens.Where(item => item.Id == new Guid("40bf5176-ebac-4b14-aaf8-da474480e432")).FirstOrDefault()));
            #endregion

            foreach (var movie in Movies)
            {
                movie.Screenings = Screenings.Where(item => item.Movie != null && item.Movie.Id == movie.Id).ToList();
            }
        }

        /// <summary>
        /// Inicjalizacja listy sal kinowych
        /// </summary>
        private void InitScreens()
        {
            Screens = new List<Screen>();
            Screens.Add(new Screen { Id = new Guid("40bf5176-ebac-4b14-aaf8-da474480e432"), Name = "1", Size = 149 });
            Screens.Add(new Screen { Id = new Guid("6bb909d4-57a4-48a3-b067-65edbe64ad3d"), Name = "2", Size = 180 });
            Screens.Add(new Screen { Id = new Guid("694025a3-c7a5-4464-a78a-ce666f19da37"), Name = "3", Size = 149 });
        }

        /// <summary>
        /// Inicjalizacja listy siedzeń
        /// </summary>
        private void InitSeats()
        {
            Seats = new List<Seat>();
            for (int i = 0; i < 12; i++) {
                for (int j = 0; j < 16; j++)
                {
                    if ((i == 0 && j < 9) || ((i > 0 && i < 9) && j < 12) || ((i == 9 || i == 10) &&  j < 14) || i == 15)
                    {
                        Seats.Add(new Seat { Id = Guid.NewGuid(), SeatNumber = j + 1, Row = i + 1, Screen = Screens.Where(item => item.Id == new Guid("40bf5176-ebac-4b14-aaf8-da474480e432")).FirstOrDefault() });
                        Seats.Add(new Seat { Id = Guid.NewGuid(), SeatNumber = j + 1, Row = i + 1, Screen = Screens.Where(item => item.Id == new Guid("694025a3-c7a5-4464-a78a-ce666f19da37")).FirstOrDefault() });
                    }
                }   
            }

            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    if ((i == 0 && j < 12) || ((i == 1 || i == 2 || i == 10) && j < 13) || (i > 2 && i < 10) || i > 10)
                    {
                        Seats.Add(new Seat { Id = Guid.NewGuid(), SeatNumber = j + 1, Row = i + 1, Screen = Screens.Where(item => item.Id == new Guid("6bb909d4-57a4-48a3-b067-65edbe64ad3d")).FirstOrDefault() });
                    }
                }
            }

            foreach (var screen in Screens)
                screen.Seats = Seats.Where(item => item.Screen.Id == screen.Id).ToList();
        }

        /// <summary>
        /// Inicjalizacja listy użytkowników
        /// </summary>
        private void InitUsers()
        {
            Users = new List<User>
            {
                new User (new Guid("0a3c1947-19de-4942-a2dd-0bf2a2c9cff5"), "kontakt@norlowska.com", "epMz1AKqh2IAZvi+qcRbxAWOGCfaQBqhLGyU98g5pgDiTsCA", "Natalia", "Orłowska")
            };
        }

        public ICollection<User> Users { get; set; }
        public ICollection<CrewMember> CrewMembers { get; set; }
        public ICollection<Character> Characters { get; set; }
        public ICollection<Actor> Actors{ get; set; }
        public ICollection<Movie> Movies{ get; set; }
        public ICollection<Reservation> Reservations{ get; set; }
        public ICollection<Screening> Screenings{ get; set; }
        public ICollection<Seat> Seats { get; set; }
        public ICollection<Screen> Screens { get; set; }
    }
}