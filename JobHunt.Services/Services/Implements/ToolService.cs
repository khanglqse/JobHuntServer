//using JobHunt.Services.Services.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using JobHunt.Services.Models.Administration;

//using JobHunt.DataAccess;
//using JobHunt.DataAccess.Entities;
//using AutoMapper;
//using JobHunt.Core.Data;
//using JobHunt.Core.Data.Entity;

//namespace JobHunt.Services.Services.Implements
//{
//    public class ToolService : IToolService
//    {

//        private readonly IUnitOfWorkFactory<UnitOfWork, JobHuntContext> _unitOfWork;

//        public ToolService(IUnitOfWorkFactory<UnitOfWork, JobHuntContext> unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }

//        public bool CheckExistingTool(Guid id, string title)
//        {
//            using (var unit = _unitOfWork.Create())
//            {
//                var item = unit.Repository<Tool>().
//                    FirstOrDefault(tool => tool.Id != id &&
//                                            tool.Name == title &&
//                                            tool.IsDeleted == false);
//                return item != null;
//            }
//        }

//        public bool CreateUpdateTool(ToolModel model)
//        {
//            try
//            {
//                using (var uow = _unitOfWork.Create())
//                {
//                    //Update
//                    if (model.Id != Guid.Empty)
//                    {
//                        this.UpdateTool(uow, model);
//                    }
//                    //Create
//                    else
//                    {
//                        this.CreateTool(uow, model);
//                    }

//                    return uow.SaveChanges() > 0;
//                }
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }


//        public bool DeleteTool(Guid id)
//        {
//            try
//            {
//                using (var uow = _unitOfWork.Create())
//                {
//                    var tool = uow.Repository<Tool>().FirstOrDefault(k => k.Id == id);
//                    if (tool != null)
//                    {
//                        tool.IsDeleted = true;
//                    }
//                    else
//                    {
//                        return false;
//                    }

//                    return uow.SaveChanges() > 0;
//                }
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        public List<ToolModel> GetListActiveTool()
//        {
//            try
//            {
//                using (var uow = _unitOfWork.Create())
//                {
//                    List<ToolModel> models = null;
//                    var lstTool = uow.Repository<Tool>().
//                        Where(tool => tool.IsDeleted == false).
//                        ToList();
//                    models = Mapper.Map<List<ToolModel>>(lstTool);
//                    return models;
//                }
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        public List<ToolModel> GetListTool()
//        {
//            try
//            {
//                using (var uow = _unitOfWork.Create())
//                {
//                    List<ToolModel> models = null;
//                    var lstTool = uow.Repository<Tool>().
//                        ToList();
//                    models = Mapper.Map<List<ToolModel>>(lstTool);
//                    foreach (var item in models)
//                    {
//                        item.Active = !item.IsDeleted;
//                    }
//                    return models;
//                }
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        public ToolModel GetTool(Guid id)
//        {
//            if (id != Guid.Empty)
//            {
//                using (var data = _unitOfWork.Create())
//                {
//                    var tool = data.Repository<Tool>().
//                        Where(a => a.Id == id).
//                        FirstOrDefault();
//                    if (tool != null)
//                    {
//                        return new ToolModel()
//                        {
//                            Id = tool.Id,
//                            Name = tool.Name,
//                            URL = tool.URL,
//                            Active = !tool.IsDeleted,
//                        };
//                    }
//                    else return null;
//                }
//            }
//            return null;
//        }

//        #region Private Function
//        private void CreateTool(UnitOfWork uow, ToolModel model)
//        {
//            Tool tool = Mapper.Map<ToolModel, Tool>(model);
//            tool.IsDeleted = !model.Active;
//            uow.Repository<Tool>().Add(tool);
//        }

//        private void UpdateTool(UnitOfWork uow, ToolModel model)
//        {
//            Tool tool = uow.Repository<Tool>().FirstOrDefault(k => k.Id == model.Id);
//            if (tool != null)
//            {
//                tool.Name = model.Name;
//                tool.URL = model.URL;
//                tool.IsDeleted = !model.Active;
//            }
//        }
//        #endregion
//    }
//}
