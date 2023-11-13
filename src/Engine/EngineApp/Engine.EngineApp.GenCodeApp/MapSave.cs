using Engine.Domain.Post;
using Engine.Domain.User;
using Engine.Domain.Comment;
using Engine.Contracts.Post;

using Engine.Application.AppServices.Structure.Repositories;
using Engine.Contracts.Comment;
using Engine.Contracts.User;
using Engine.Infrastructure.DataAccess.Configuration;
using Engine.Infrastructure.DataAccess.Repository;
using Engine.Domain.Community;
using Engine.Contracts.Community;
using Engine.Domain.Product;
using Engine.Contracts.Product;
using Engine.Domain.Feedback;
using Engine.Contracts.Feedback;
using Engine.Domain.Voting;
using Engine.Contracts.Voting;
using Engine.Domain.Bidding;
using Engine.Contracts.Bidding;
using Engine.Domain.Bookmarks;
using Engine.Contracts.Bookmark;
using Engine.Domain.History;
using Engine.Contracts.History;
using Engine.Domain.Category;
using Engine.Contracts.Category;

namespace Engine.EngineApp.GenCodeApp
{
    public class MapSave
    {
        public string BaseDir;

        public MapSave(string path)
        {
            BaseDir = path;
            //Saver 
            //Console.WriteLine("Substring: " + BaseDir);
        }

        public void Run()
        {
            string DomainDir = BaseDir + "/Dashboard/Domain/Dashboard.Domain";
            string ContractDir = BaseDir + "/Dashboard/Contracts/Dashboard.Contracts";
            string AppStructure = BaseDir + "/Dashboard/Application/Dashboard.Application.AppServices/";
            string InfrastructureDir = BaseDir + "/Dashboard/Infrastructure/Dashboard.Infrastructure.DataAccess/Context"; // "/Post/Repository"; "/Post/Configuration";

            //Saver.Save();
            // Post
            /*await*/ GenSave.Save(DomainDir + "/Posts/Post.cs", new GenPost().TransformText());
            /*await*/ GenSave.Save(ContractDir + "/Post/PostDto.cs", new GenPostDto().TransformText());
            /*await*/ GenSave.Save(ContractDir + "/Post/UpdatePostDto.cs", new GenUpdatePostDto().TransformText());
            // Comment
            /*await*/ GenSave.Save(DomainDir + "/Comments/Comment.cs", new GenComment().TransformText());
            /*await*/ GenSave.Save(ContractDir + "/Comment/CommentDto.cs", new GenCommentDto().TransformText());
            /*await*/ GenSave.Save(ContractDir + "/Comment/CreateCommentDto.cs", new GenCreateCommentDto().TransformText());
            /*await*/ GenSave.Save(ContractDir + "/Comment/UpdateCommentDto.cs", new GenUpdateCommentDto().TransformText());
            // User
            string tdir = "User";
            /*await*/ GenSave.Save(DomainDir +"/" + tdir + "s/" + tdir + ".cs", new GenUser().TransformText());
            /*await*/ GenSave.Save(ContractDir + "/" + tdir + "/" + tdir + "Dto.cs", new GenUserDto().TransformText());
            /*await*/ GenSave.Save(ContractDir + "/" + tdir + "/Create" + tdir + "Dto.cs", new GenCreateUserDto().TransformText());
            /*await*/ GenSave.Save(ContractDir + "/" + tdir + "/Update" + tdir + "Dto.cs", new GenUpdateUserDto().TransformText());
            // Community
            tdir = "Community";
            /*await*/ GenSave.Save(DomainDir + "/" + tdir + "s/" + tdir + ".cs", new GenCommunity().TransformText());
            /*await*/ GenSave.Save(ContractDir + "/" + tdir + "/" + tdir + "Dto.cs", new GenCommunityDto().TransformText());
            /*await*/ GenSave.Save(ContractDir + "/" + tdir + "/Create" + tdir + "Dto.cs", new GenCreateCommunityDto().TransformText());
            /*await*/ GenSave.Save(ContractDir + "/" + tdir + "/Update" + tdir + "Dto.cs", new GenUpdateCommunityDto().TransformText());
            // Product
            tdir = "Product";
            /*await*/ GenSave.Save(DomainDir + "/" + tdir + "s/" + tdir + ".cs", new GenProduct().TransformText());
            /*await*/ GenSave.Save(ContractDir + "/" + tdir + "/" + tdir + "Dto.cs", new GenProductDto().TransformText());
            /*await*/ GenSave.Save(ContractDir + "/" + tdir + "/Create" + tdir + "Dto.cs", new GenCreateProductDto().TransformText());
            /*await*/ GenSave.Save(ContractDir + "/" + tdir + "/Update" + tdir + "Dto.cs", new GenUpdateProductDto().TransformText());
            // Feedback
            tdir = "Feedback";
            /*await*/ GenSave.Save(DomainDir + "/" + tdir + "s/" + tdir + ".cs", new GenFeedback().TransformText());
            /*await*/ GenSave.Save(ContractDir + "/" + tdir + "/" + tdir + "Dto.cs", new GenFeedbackDto().TransformText());
            /*await*/ GenSave.Save(ContractDir + "/" + tdir + "/Create" + tdir + "Dto.cs", new GenCreateFeedbackDto().TransformText());
            /*await*/ GenSave.Save(ContractDir + "/" + tdir + "/Update" + tdir + "Dto.cs", new GenUpdateFeedbackDto().TransformText());
            // Voting
            tdir = "Voting";
            /*await*/ GenSave.Save(DomainDir + "/" + tdir + "s/" + tdir + ".cs", new GenVoting().TransformText());
            /*await*/ GenSave.Save(ContractDir + "/" + tdir + "/" + tdir + "Dto.cs", new GenVotingDto().TransformText());
            /*await*/ GenSave.Save(ContractDir + "/" + tdir + "/Create" + tdir + "Dto.cs", new GenCreateVotingDto().TransformText());
            /*await*/ GenSave.Save(ContractDir + "/" + tdir + "/Update" + tdir + "Dto.cs", new GenUpdateVotingDto().TransformText());
            // Post
            tdir = "Bidding";
            /*await*/ GenSave.Save(DomainDir + "/" + tdir + "s/" + tdir + ".cs", new GenBidding().TransformText());
            /*await*/ GenSave.Save(ContractDir + "/" + tdir + "/" + tdir + "Dto.cs", new GenBiddingDto().TransformText());
            /*await*/ GenSave.Save(ContractDir + "/" + tdir + "/Create" + tdir + "Dto.cs", new GenCreateBiddingDto().TransformText());
            /*await*/ GenSave.Save(ContractDir + "/" + tdir + "/Update" + tdir + "Dto.cs", new GenUpdateBiddingDto().TransformText());
            // Bookmark
            tdir = "Bookmark";
            /*await*/ GenSave.Save(DomainDir + "/" + tdir + "s/" + tdir + ".cs", new GenBookmark().TransformText());
            /*await*/ GenSave.Save(ContractDir + "/" + tdir + "/" + tdir + "Dto.cs", new GenBookmarkDto().TransformText());
            /*await*/ GenSave.Save(ContractDir + "/" + tdir + "/Create" + tdir + "Dto.cs", new GenCreateBookmarkDto().TransformText());
            /*await*/ GenSave.Save(ContractDir + "/" + tdir + "/Update" + tdir + "Dto.cs", new GenUpdateBookmarkDto().TransformText());
            // History
            tdir = "History";
            /*await*/ GenSave.Save(DomainDir + "/" + tdir + "s/" + tdir + ".cs", new GenHistory().TransformText());
            /*await*/ GenSave.Save(ContractDir + "/" + tdir + "/" + tdir + "Dto.cs", new GenHistoryDto().TransformText());
            /*await*/ GenSave.Save(ContractDir + "/" + tdir + "/Create" + tdir + "Dto.cs", new GenCreateHistoryDto().TransformText());
            /*await*/ GenSave.Save(ContractDir + "/" + tdir + "/Update" + tdir + "Dto.cs", new GenUpdateHistoryDto().TransformText());
            // Tag
            tdir = "Tag";
            /*await*/ GenSave.Save(DomainDir + "/" + tdir + "s/" + tdir + ".cs", new GenHistory().TransformText());
            /*await*/ GenSave.Save(ContractDir + "/" + tdir + "/" + tdir + "Dto.cs", new GenHistoryDto().TransformText());
            /*await*/ GenSave.Save(ContractDir + "/" + tdir + "/Create" + tdir + "Dto.cs", new GenCreateHistoryDto().TransformText());
            /*await*/ GenSave.Save(ContractDir + "/" + tdir + "/Update" + tdir + "Dto.cs", new GenUpdateHistoryDto().TransformText());
            // Category
            tdir = "Category";
            /*await*/ GenSave.Save(DomainDir + "/" + tdir + "s/" + tdir + ".cs", new GenCategory().TransformText());
            /*await*/ GenSave.Save(ContractDir + "/" + tdir + "/" + tdir + "Dto.cs", new GenCategoryDto().TransformText());
            /*await*/ GenSave.Save(ContractDir + "/" + tdir + "/Create" + tdir + "Dto.cs", new GenCreateCategoryDto().TransformText());
            /*await*/ GenSave.Save(ContractDir + "/" + tdir + "/Update" + tdir + "Dto.cs", new GenUpdateCategoryDto().TransformText());

            GenIStructureRepositories g = new GenIStructureRepositories();
            g.GenerationEnvironment.Clear(); // Самый первый раз очищать необязательно
            g.Name1 = "Post";
            g.ModelUsing = "Domain";
            g.ModelUsingS = "s";
            g.ModelDomain = "Domain.Posts.Post";
            g.ModelService = g.ModelDomain;
            g.ModelCreate = g.ModelDomain;
            g.ModelUpdate = g.ModelDomain;
            g.ModelDelete = g.ModelDomain + " model";
            g.GetTypeList = "IQueryable < Domain.Posts.Post >";
            g.TypeGen = "Repository"; // Repository OR Service
            g.TypeGenMulti = "Repositories"; // Repositories OR Services
            g.HelpClass = "Репозиторий для работы с объявлениями.";
            g.HelpName = "Объявление";
            g.HelpName2 = "Объявления";
            g.ToComment = "//";
            /*await*/ GenSave.Save(AppStructure + "/"+ g.Name1 +"/" + g.TypeGenMulti + "/I"+ g.Name1 + g.TypeGen + ".cs", g.TransformText());
            g.GenerationEnvironment.Clear();
            g.ModelUsing = "Contracts";
            g.ModelUsingS = "";
            g.HelpClass = "Сервис работы с объявлениями.";
            g.ModelService = "PostDto";
            g.ModelCreate = "CreatePostDto";
            g.ModelUpdate = "UpdatePostDto";
            g.ModelDelete = "Guid id";
            g.GetTypeList = "Task<PostDto[]>";
            g.TypeGen = "Service"; // Repository OR Service
            g.TypeGenMulti = "Services"; // Repositories OR Services
            g.ToComment = "";
            /*await*/ GenSave.Save(AppStructure + "/" + g.Name1 + "/" + g.TypeGenMulti + "/I" + g.Name1 + g.TypeGen + ".cs", g.TransformText());

            // Comment
            g.GenerationEnvironment.Clear();
            g.Name1 = "Comment";
            g.ModelUsing = "Domain";
            g.ModelUsingS = "s";
            g.ModelDomain = "Domain.Comments.Comment";
            g.ModelService = g.ModelDomain;
            g.ModelCreate = g.ModelDomain;
            g.ModelUpdate = g.ModelDomain;
            g.ModelDelete = g.ModelDomain + " model";
            g.GetTypeList = "IQueryable < Domain.Comments.Comment >";
            g.TypeGen = "Repository";
            g.TypeGenMulti = "Repositories";
            g.HelpClass = "Репозиторий для работы с комментариями.";
            g.HelpName = "Комментарий";
            g.HelpName2 = "Комментария";
            g.ToComment = "//";
            /*await*/ GenSave.Save(AppStructure + "/" + g.Name1 + "/" + g.TypeGenMulti + "/I" + g.Name1 + g.TypeGen + ".cs", g.TransformText());
            g.GenerationEnvironment.Clear();
            g.ModelUsing = "Contracts";
            g.ModelUsingS = "";
            g.HelpClass = "Сервис работы с комментариями.";
            g.ModelService = "CommentDto";
            g.ModelCreate = "CreateCommentDto";
            g.ModelUpdate = "UpdateCommentDto";
            g.ModelDelete = "Guid id";
            g.GetTypeList = "Task<CommentDto[]>";
            g.TypeGen = "Service";
            g.TypeGenMulti = "Services";
            g.ToComment = "";
            /*await*/ GenSave.Save(AppStructure + "/" + g.Name1 + "/" + g.TypeGenMulti + "/I" + g.Name1 + g.TypeGen + ".cs", g.TransformText());

            // User
            g.GenerationEnvironment.Clear();
            g.Name1 = "User";
            g.ModelUsing = "Domain";
            g.ModelUsingS = "s";
            g.ModelDomain = "Domain."+ g.Name1 + "s."+ g.Name1;
            g.ModelService = g.ModelDomain;
            g.ModelCreate = g.ModelDomain;
            g.ModelUpdate = g.ModelDomain;
            g.ModelDelete = g.ModelDomain + " model";
            g.GetTypeList = "IQueryable < "+ g.ModelDomain + " >";
            g.TypeGen = "Repository";
            g.TypeGenMulti = "Repositories";
            g.HelpClass = "Репозиторий для работы с пользователями.";
            g.HelpName = "Пользователь";
            g.HelpName2 = "Пользователя";
            g.ToComment = "//";
            /*await*/ GenSave.Save(AppStructure + "/" + g.Name1 + "/" + g.TypeGenMulti + "/I" + g.Name1 + g.TypeGen + ".cs", g.TransformText());
            g.GenerationEnvironment.Clear();
            g.ModelUsing = "Contracts";
            g.ModelUsingS = "";
            g.HelpClass = "Сервис работы с пользователями.";
            g.ModelService = g.Name1+"Dto";
            g.ModelCreate = "Create"+ g.Name1 + "Dto";
            g.ModelUpdate = "Update"+ g.Name1 + "Dto";
            g.ModelDelete = "Guid id";
            g.GetTypeList = "Task<"+ g.ModelService + "[]>";
            g.TypeGen = "Service";
            g.TypeGenMulti = "Services";
            g.ToComment = "";
            /*await*/ GenSave.Save(AppStructure + "/" + g.Name1 + "/" + g.TypeGenMulti + "/I" + g.Name1 + g.TypeGen + ".cs", g.TransformText());

            // Community
            g.GenerationEnvironment.Clear();
            g.Name1 = "Community";
            g.ModelUsing = "Domain";
            g.ModelUsingS = "s";
            g.ModelDomain = "Domain." + g.Name1 + "s." + g.Name1;
            g.ModelService = g.ModelDomain;
            g.ModelCreate = g.ModelDomain;
            g.ModelUpdate = g.ModelDomain;
            g.ModelDelete = g.ModelDomain + " model";
            g.GetTypeList = "IQueryable < " + g.ModelDomain + " >";
            g.TypeGen = "Repository";
            g.TypeGenMulti = "Repositories";
            g.HelpClass = "Репозиторий для работы с сообществами.";
            g.HelpName = "Сообщество";
            g.HelpName2 = "Сообщества";
            g.ToComment = "//";
            /*await*/ GenSave.Save(AppStructure + "/" + g.Name1 + "/" + g.TypeGenMulti + "/I" + g.Name1 + g.TypeGen + ".cs", g.TransformText());
            g.GenerationEnvironment.Clear();
            g.ModelUsing = "Contracts";
            g.ModelUsingS = "";
            g.HelpClass = "Сервис работы с сообществами.";
            g.ModelService = g.Name1 + "Dto";
            g.ModelCreate = "Create" + g.Name1 + "Dto";
            g.ModelUpdate = "Update" + g.Name1 + "Dto";
            g.ModelDelete = "Guid id";
            g.GetTypeList = "Task<" + g.ModelService + "[]>";
            g.TypeGen = "Service";
            g.TypeGenMulti = "Services";
            g.ToComment = "";
            /*await*/ GenSave.Save(AppStructure + "/" + g.Name1 + "/" + g.TypeGenMulti + "/I" + g.Name1 + g.TypeGen + ".cs", g.TransformText());

            // Product
            g.GenerationEnvironment.Clear();
            g.Name1 = "Product";
            g.ModelUsing = "Domain";
            g.ModelUsingS = "s";
            g.ModelDomain = "Domain." + g.Name1 + "s." + g.Name1;
            g.ModelService = g.ModelDomain;
            g.ModelCreate = g.ModelDomain;
            g.ModelUpdate = g.ModelDomain;
            g.ModelDelete = g.ModelDomain + " model";
            g.GetTypeList = "IQueryable < " + g.ModelDomain + " >";
            g.TypeGen = "Repository";
            g.TypeGenMulti = "Repositories";
            g.HelpClass = "Репозиторий для работы с товарами.";
            g.HelpName = "Товар";
            g.HelpName2 = "Товара";
            g.ToComment = "//";
            /*await*/ GenSave.Save(AppStructure + "/" + g.Name1 + "/" + g.TypeGenMulti + "/I" + g.Name1 + g.TypeGen + ".cs", g.TransformText());
            g.GenerationEnvironment.Clear();
            g.ModelUsing = "Contracts";
            g.ModelUsingS = "";
            g.HelpClass = "Сервис работы с товарами.";
            g.ModelService = g.Name1 + "Dto";
            g.ModelCreate = "Create" + g.Name1 + "Dto";
            g.ModelUpdate = "Update" + g.Name1 + "Dto";
            g.ModelDelete = "Guid id";
            g.GetTypeList = "Task<" + g.ModelService + "[]>";
            g.TypeGen = "Service";
            g.TypeGenMulti = "Services";
            g.ToComment = "";
            /*await*/ GenSave.Save(AppStructure + "/" + g.Name1 + "/" + g.TypeGenMulti + "/I" + g.Name1 + g.TypeGen + ".cs", g.TransformText());

            // Feedback
            g.GenerationEnvironment.Clear();
            g.Name1 = "Feedback";
            g.ModelUsing = "Domain";
            g.ModelUsingS = "s";
            g.ModelDomain = "Domain." + g.Name1 + "s." + g.Name1;
            g.ModelService = g.ModelDomain;
            g.ModelCreate = g.ModelDomain;
            g.ModelUpdate = g.ModelDomain;
            g.ModelDelete = g.ModelDomain + " model";
            g.GetTypeList = "IQueryable < " + g.ModelDomain + " >";
            g.TypeGen = "Repository";
            g.TypeGenMulti = "Repositories";
            g.HelpClass = "Репозиторий для работы с отзывами.";
            g.HelpName = "Отзыв";
            g.HelpName2 = "Отзыва";
            g.ToComment = "//";
            /*await*/ GenSave.Save(AppStructure + "/" + g.Name1 + "/" + g.TypeGenMulti + "/I" + g.Name1 + g.TypeGen + ".cs", g.TransformText());
            g.GenerationEnvironment.Clear();
            g.ModelUsing = "Contracts";
            g.ModelUsingS = "";
            g.HelpClass = "Сервис работы с отзывами.";
            g.ModelService = g.Name1 + "Dto";
            g.ModelCreate = "Create" + g.Name1 + "Dto";
            g.ModelUpdate = "Update" + g.Name1 + "Dto";
            g.ModelDelete = "Guid id";
            g.GetTypeList = "Task<" + g.ModelService + "[]>";
            g.TypeGen = "Service";
            g.TypeGenMulti = "Services";
            g.ToComment = "";
            /*await*/ GenSave.Save(AppStructure + "/" + g.Name1 + "/" + g.TypeGenMulti + "/I" + g.Name1 + g.TypeGen + ".cs", g.TransformText());

            // Voting
            g.GenerationEnvironment.Clear();
            g.Name1 = "Voting";
            g.ModelUsing = "Domain";
            g.ModelUsingS = "s";
            g.ModelDomain = "Domain." + g.Name1 + "s." + g.Name1;
            g.ModelService = g.ModelDomain;
            g.ModelCreate = g.ModelDomain;
            g.ModelUpdate = g.ModelDomain;
            g.ModelDelete = g.ModelDomain + " model";
            g.GetTypeList = "IQueryable < " + g.ModelDomain + " >";
            g.TypeGen = "Repository";
            g.TypeGenMulti = "Repositories";
            g.HelpClass = "Репозиторий для работы с голосованиями.";
            g.HelpName = "Голосование";
            g.HelpName2 = "Голосования";
            g.ToComment = "//";
            /*await*/ GenSave.Save(AppStructure + "/" + g.Name1 + "/" + g.TypeGenMulti + "/I" + g.Name1 + g.TypeGen + ".cs", g.TransformText());
            g.GenerationEnvironment.Clear();
            g.ModelUsing = "Contracts";
            g.ModelUsingS = "";
            g.HelpClass = "Сервис работы с голосованиями.";
            g.ModelService = g.Name1 + "Dto";
            g.ModelCreate = "Create" + g.Name1 + "Dto";
            g.ModelUpdate = "Update" + g.Name1 + "Dto";
            g.ModelDelete = "Guid id";
            g.GetTypeList = "Task<" + g.ModelService + "[]>";
            g.TypeGen = "Service";
            g.TypeGenMulti = "Services";
            g.ToComment = "";
            /*await*/ GenSave.Save(AppStructure + "/" + g.Name1 + "/" + g.TypeGenMulti + "/I" + g.Name1 + g.TypeGen + ".cs", g.TransformText());

            // Bidding
            g.GenerationEnvironment.Clear();
            g.Name1 = "Bidding";
            g.ModelUsing = "Domain";
            g.ModelUsingS = "s";
            g.ModelDomain = "Domain." + g.Name1 + "s." + g.Name1;
            g.ModelService = g.ModelDomain;
            g.ModelCreate = g.ModelDomain;
            g.ModelUpdate = g.ModelDomain;
            g.ModelDelete = g.ModelDomain + " model";
            g.GetTypeList = "IQueryable < " + g.ModelDomain + " >";
            g.TypeGen = "Repository";
            g.TypeGenMulti = "Repositories";
            g.HelpClass = "Репозиторий для работы с аукционами.";
            g.HelpName = "Аукцион";
            g.HelpName2 = "Аукционы";
            g.ToComment = "//";
            /*await*/ GenSave.Save(AppStructure + "/" + g.Name1 + "/" + g.TypeGenMulti + "/I" + g.Name1 + g.TypeGen + ".cs", g.TransformText());
            g.GenerationEnvironment.Clear();
            g.ModelUsing = "Contracts";
            g.ModelUsingS = "";
            g.HelpClass = "Сервис работы с аукционами.";
            g.ModelService = g.Name1 + "Dto";
            g.ModelCreate = "Create" + g.Name1 + "Dto";
            g.ModelUpdate = "Update" + g.Name1 + "Dto";
            g.ModelDelete = "Guid id";
            g.GetTypeList = "Task<" + g.ModelService + "[]>";
            g.TypeGen = "Service";
            g.TypeGenMulti = "Services";
            g.ToComment = "";
            /*await*/ GenSave.Save(AppStructure + "/" + g.Name1 + "/" + g.TypeGenMulti + "/I" + g.Name1 + g.TypeGen + ".cs", g.TransformText());

            // Bookmark
            g.GenerationEnvironment.Clear();
            g.Name1 = "Bookmark";
            g.ModelUsing = "Domain";
            g.ModelUsingS = "s";
            g.ModelDomain = "Domain." + g.Name1 + "s." + g.Name1;
            g.ModelService = g.ModelDomain;
            g.ModelCreate = g.ModelDomain;
            g.ModelUpdate = g.ModelDomain;
            g.ModelDelete = g.ModelDomain + " model";
            g.GetTypeList = "IQueryable < " + g.ModelDomain + " >";
            g.TypeGen = "Repository";
            g.TypeGenMulti = "Repositories";
            g.HelpClass = "Репозиторий для работы с закладками.";
            g.HelpName = "Закладка";
            g.HelpName2 = "Закладки";
            g.ToComment = "//";
            /*await*/ GenSave.Save(AppStructure + "/" + g.Name1 + "/" + g.TypeGenMulti + "/I" + g.Name1 + g.TypeGen + ".cs", g.TransformText());
            g.GenerationEnvironment.Clear();
            g.ModelUsing = "Contracts";
            g.ModelUsingS = "";
            g.HelpClass = "Сервис работы с закладками.";
            g.ModelService = g.Name1 + "Dto";
            g.ModelCreate = "Create" + g.Name1 + "Dto";
            g.ModelUpdate = "Update" + g.Name1 + "Dto";
            g.ModelDelete = "Guid id";
            g.GetTypeList = "Task<" + g.ModelService + "[]>";
            g.TypeGen = "Service";
            g.TypeGenMulti = "Services";
            g.ToComment = "";
            /*await*/ GenSave.Save(AppStructure + "/" + g.Name1 + "/" + g.TypeGenMulti + "/I" + g.Name1 + g.TypeGen + ".cs", g.TransformText());

            // History
            g.GenerationEnvironment.Clear();
            g.Name1 = "History";
            g.ModelUsing = "Domain";
            g.ModelUsingS = "s";
            g.ModelDomain = "Domain." + g.Name1 + "s." + g.Name1;
            g.ModelService = g.ModelDomain;
            g.ModelCreate = g.ModelDomain;
            g.ModelUpdate = g.ModelDomain;
            g.ModelDelete = g.ModelDomain + " model";
            g.GetTypeList = "IQueryable < " + g.ModelDomain + " >";
            g.TypeGen = "Repository";
            g.TypeGenMulti = "Repositories";
            g.HelpClass = "Репозиторий для работы с историями просмотра.";
            g.HelpName = "История просмотра";
            g.HelpName2 = "Истории просмостра";
            g.ToComment = "//";
            /*await*/ GenSave.Save(AppStructure + "/" + g.Name1 + "/" + g.TypeGenMulti + "/I" + g.Name1 + g.TypeGen + ".cs", g.TransformText());
            g.GenerationEnvironment.Clear();
            g.ModelUsing = "Contracts";
            g.ModelUsingS = "";
            g.HelpClass = "Сервис работы с историями просмотра.";
            g.ModelService = g.Name1 + "Dto";
            g.ModelCreate = "Create" + g.Name1 + "Dto";
            g.ModelUpdate = "Update" + g.Name1 + "Dto";
            g.ModelDelete = "Guid id";
            g.GetTypeList = "Task<" + g.ModelService + "[]>";
            g.TypeGen = "Service";
            g.TypeGenMulti = "Services";
            g.ToComment = "";
            /*await*/ GenSave.Save(AppStructure + "/" + g.Name1 + "/" + g.TypeGenMulti + "/I" + g.Name1 + g.TypeGen + ".cs", g.TransformText());

            
            // Tag
            g.GenerationEnvironment.Clear();
            g.Name1 = "Tag";
            g.ModelUsing = "Domain";
            g.ModelUsingS = "s";
            g.ModelDomain = "Domain." + g.Name1 + "s." + g.Name1;
            g.ModelService = g.ModelDomain;
            g.ModelCreate = g.ModelDomain;
            g.ModelUpdate = g.ModelDomain;
            g.ModelDelete = g.ModelDomain + " model";
            g.GetTypeList = "IQueryable < " + g.ModelDomain + " >";
            g.TypeGen = "Repository";
            g.TypeGenMulti = "Repositories";
            g.HelpClass = "Репозиторий для работы с тегами.";
            g.HelpName = "Тег";
            g.HelpName2 = "Тега";
            g.ToComment = "//";
            /*await*/ GenSave.Save(AppStructure + "/" + g.Name1 + "/" + g.TypeGenMulti + "/I" + g.Name1 + g.TypeGen + ".cs", g.TransformText());
            g.GenerationEnvironment.Clear();
            g.ModelUsing = "Contracts";
            g.ModelUsingS = "";
            g.HelpClass = "Сервис работы с тегами.";
            g.ModelService = g.Name1 + "Dto";
            g.ModelCreate = "Create" + g.Name1 + "Dto";
            g.ModelUpdate = "Update" + g.Name1 + "Dto";
            g.ModelDelete = "Guid id";
            g.GetTypeList = "Task<" + g.ModelService + "[]>";
            g.TypeGen = "Service";
            g.TypeGenMulti = "Services";
            g.ToComment = "";
            /*await*/ GenSave.Save(AppStructure + "/" + g.Name1 + "/" + g.TypeGenMulti + "/I" + g.Name1 + g.TypeGen + ".cs", g.TransformText());

            // Category
            g.GenerationEnvironment.Clear();
            g.Name1 = "Category";
            g.ModelUsing = "Domain";
            g.ModelUsingS = "s";
            g.ModelDomain = "Domain." + g.Name1 + "s." + g.Name1;
            g.ModelService = g.ModelDomain;
            g.ModelCreate = g.ModelDomain;
            g.ModelUpdate = g.ModelDomain;
            g.ModelDelete = g.ModelDomain + " model";
            g.GetTypeList = "IQueryable < " + g.ModelDomain + " >";
            g.TypeGen = "Repository";
            g.TypeGenMulti = "Repositories";
            g.HelpClass = "Репозиторий для работы с категориями.";
            g.HelpName = "Категория";
            g.HelpName2 = "Категории";
            g.ToComment = "//";
            /*await*/ GenSave.Save(AppStructure + "/" + g.Name1 + "/" + g.TypeGenMulti + "/I" + g.Name1 + g.TypeGen + ".cs", g.TransformText());
            g.GenerationEnvironment.Clear();
            g.ModelUsing = "Contracts";
            g.ModelUsingS = "";
            g.HelpClass = "Сервис работы с категориями.";
            g.ModelService = g.Name1 + "Dto";
            g.ModelCreate = "Create" + g.Name1 + "Dto";
            g.ModelUpdate = "Update" + g.Name1 + "Dto";
            g.ModelDelete = "Guid id";
            g.GetTypeList = "Task<" + g.ModelService + "[]>";
            g.TypeGen = "Service";
            g.TypeGenMulti = "Services";
            g.ToComment = "";
            /*await*/ GenSave.Save(AppStructure + "/" + g.Name1 + "/" + g.TypeGenMulti + "/I" + g.Name1 + g.TypeGen + ".cs", g.TransformText());
            

            GenConfiguration c = new GenConfiguration();
            

            c.GenerationEnvironment.Clear();
            c.Name1 = "Post";
            c.ModelDomain = "Domain."+ c.Name1 + "s."+ c.Name1;
            /*await*/ GenSave.Save(InfrastructureDir + "/"+ c.Name1 + "/Configuration/"+ c.Name1 + "Configuration.cs", c.TransformText());

            c.GenerationEnvironment.Clear();
            c.Name1 = "Comment";
            c.ModelDomain = "Domain." + c.Name1 + "s." + c.Name1;
            /*await*/ GenSave.Save(InfrastructureDir + "/" + c.Name1 + "/Configuration/" + c.Name1 + "Configuration.cs", c.TransformText());

            c.GenerationEnvironment.Clear();
            c.Name1 = "User";
            c.ModelDomain = "Domain." + c.Name1 + "s." + c.Name1;
            /*await*/ GenSave.Save(InfrastructureDir + "/" + c.Name1 + "/Configuration/" + c.Name1 + "Configuration.cs", c.TransformText());
            
            c.GenerationEnvironment.Clear();
            c.Name1 = "Community";
            c.ModelDomain = "Domain." + c.Name1 + "s." + c.Name1;
            /*await*/ GenSave.Save(InfrastructureDir + "/" + c.Name1 + "/Configuration/" + c.Name1 + "Configuration.cs", c.TransformText());

            c.GenerationEnvironment.Clear();
            c.Name1 = "Product";
            c.ModelDomain = "Domain." + c.Name1 + "s." + c.Name1;
            /*await*/ GenSave.Save(InfrastructureDir + "/" + c.Name1 + "/Configuration/" + c.Name1 + "Configuration.cs", c.TransformText());

            c.GenerationEnvironment.Clear();
            c.Name1 = "Feedback";
            c.ModelDomain = "Domain." + c.Name1 + "s." + c.Name1;
            /*await*/ GenSave.Save(InfrastructureDir + "/" + c.Name1 + "/Configuration/" + c.Name1 + "Configuration.cs", c.TransformText());

            c.GenerationEnvironment.Clear();
            c.Name1 = "Voting";
            c.ModelDomain = "Domain." + c.Name1 + "s." + c.Name1;
            /*await*/ GenSave.Save(InfrastructureDir + "/" + c.Name1 + "/Configuration/" + c.Name1 + "Configuration.cs", c.TransformText());

            c.GenerationEnvironment.Clear();
            c.Name1 = "Bidding";
            c.ModelDomain = "Domain." + c.Name1 + "s." + c.Name1;
            /*await*/ GenSave.Save(InfrastructureDir + "/" + c.Name1 + "/Configuration/" + c.Name1 + "Configuration.cs", c.TransformText());

            c.GenerationEnvironment.Clear();
            c.Name1 = "Bookmark";
            c.ModelDomain = "Domain." + c.Name1 + "s." + c.Name1;
            /*await*/ GenSave.Save(InfrastructureDir + "/" + c.Name1 + "/Configuration/" + c.Name1 + "Configuration.cs", c.TransformText());

            c.GenerationEnvironment.Clear();
            c.Name1 = "History";
            c.ModelDomain = "Domain." + c.Name1 + "s." + c.Name1;
            /*await*/ GenSave.Save(InfrastructureDir + "/" + c.Name1 + "/Configuration/" + c.Name1 + "Configuration.cs", c.TransformText());

            c.GenerationEnvironment.Clear();
            c.Name1 = "Tag";
            c.ModelDomain = "Domain." + c.Name1 + "s." + c.Name1;
            /*await*/ GenSave.Save(InfrastructureDir + "/" + c.Name1 + "/Configuration/" + c.Name1 + "Configuration.cs", c.TransformText());

            c.GenerationEnvironment.Clear();
            c.Name1 = "Category";
            c.ModelDomain = "Domain." + c.Name1 + "s." + c.Name1;
            /*await*/ GenSave.Save(InfrastructureDir + "/" + c.Name1 + "/Configuration/" + c.Name1 + "Configuration.cs", c.TransformText());

            GenRepository r = new GenRepository();
            
            r.GenerationEnvironment.Clear();
            r.Name1 = "Post";
            r.ModelDomain = "Domain." + r.Name1 + "s." + r.Name1;
            /*await*/ GenSave.Save(InfrastructureDir + "/" + r.Name1 + "/Repository/"+ r.Name1 + "Repository.cs", r.TransformText());

            r.GenerationEnvironment.Clear();
            r.Name1 = "Comment";
            r.ModelDomain = "Domain." + r.Name1 + "s." + r.Name1;
            /*await*/ GenSave.Save(InfrastructureDir + "/" + r.Name1 + "/Repository/" + r.Name1 + "Repository.cs", r.TransformText());

            r.GenerationEnvironment.Clear();
            r.Name1 = "User";
            r.ModelDomain = "Domain." + r.Name1 + "s." + r.Name1;
            /*await*/ GenSave.Save(InfrastructureDir + "/" + r.Name1 + "/Repository/" + r.Name1 + "Repository.cs", r.TransformText());
            // 9
            r.GenerationEnvironment.Clear();
            r.Name1 = "Community";
            r.ModelDomain = "Domain." + r.Name1 + "s." + r.Name1;
            /*await*/ GenSave.Save(InfrastructureDir + "/" + r.Name1 + "/Repository/" + r.Name1 + "Repository.cs", r.TransformText());

            r.GenerationEnvironment.Clear();
            r.Name1 = "Product";
            r.ModelDomain = "Domain." + r.Name1 + "s." + r.Name1;
            /*await*/ GenSave.Save(InfrastructureDir + "/" + r.Name1 + "/Repository/" + r.Name1 + "Repository.cs", r.TransformText());

            r.GenerationEnvironment.Clear();
            r.Name1 = "Feedback";
            r.ModelDomain = "Domain." + r.Name1 + "s." + r.Name1;
            /*await*/ GenSave.Save(InfrastructureDir + "/" + r.Name1 + "/Repository/" + r.Name1 + "Repository.cs", r.TransformText());

            r.GenerationEnvironment.Clear();
            r.Name1 = "Voting";
            r.ModelDomain = "Domain." + r.Name1 + "s." + r.Name1;
            /*await*/ GenSave.Save(InfrastructureDir + "/" + r.Name1 + "/Repository/" + r.Name1 + "Repository.cs", r.TransformText());

            r.GenerationEnvironment.Clear();
            r.Name1 = "Bidding";
            r.ModelDomain = "Domain." + r.Name1 + "s." + r.Name1;
            /*await*/ GenSave.Save(InfrastructureDir + "/" + r.Name1 + "/Repository/" + r.Name1 + "Repository.cs", r.TransformText());

            r.GenerationEnvironment.Clear();
            r.Name1 = "Bookmark";
            r.ModelDomain = "Domain." + r.Name1 + "s." + r.Name1;
            /*await*/ GenSave.Save(InfrastructureDir + "/" + r.Name1 + "/Repository/" + r.Name1 + "Repository.cs", r.TransformText());

            r.GenerationEnvironment.Clear();
            r.Name1 = "History";
            r.ModelDomain = "Domain." + r.Name1 + "s." + r.Name1;
            /*await*/ GenSave.Save(InfrastructureDir + "/" + r.Name1 + "/Repository/" + r.Name1 + "Repository.cs", r.TransformText());

            r.GenerationEnvironment.Clear();
            r.Name1 = "Tag";
            r.ModelDomain = "Domain." + r.Name1 + "s." + r.Name1;
            /*await*/ GenSave.Save(InfrastructureDir + "/" + r.Name1 + "/Repository/" + r.Name1 + "Repository.cs", r.TransformText());

            r.GenerationEnvironment.Clear();
            r.Name1 = "Category";
            r.ModelDomain = "Domain." + r.Name1 + "s." + r.Name1;
            /*await*/ GenSave.Save(InfrastructureDir + "/" + r.Name1 + "/Repository/" + r.Name1 + "Repository.cs", r.TransformText());
        }
    }
}
