﻿// <auto-generated />
namespace Vidly.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.4.4")]
    public sealed partial class RemovingGenreInMoviesDBToAddGenreIdForeignKey : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(RemovingGenreInMoviesDBToAddGenreIdForeignKey));
        
        string IMigrationMetadata.Id
        {
            get { return "202204250159281_RemovingGenreInMoviesDBToAddGenreIdForeignKey"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}