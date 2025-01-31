using AutoMapper;
using System.Diagnostics;
using todo_list_enh.Server.Data;
using todo_list_enh.Server.Models.DTO.Activity;
using todo_list_enh.Server.Models.DTO.Task;
using todo_list_enh.Server.Services.Interfaces;

namespace todo_list_enh.Server.Services.Implementations
{
    public class ActivityService<TActivity, TTask> : IActivityService<TActivity, TTask>
    where TActivity : class
    where TTask : class
    {
        private readonly ETLDbContext _context;
        private readonly IMapper _mapper;

        public ActivityService(ETLDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddActivity(AddActivityDTO dto)
        {
            var activity = _mapper.Map<TActivity>(dto);

            await _context.Set<TActivity>().AddAsync(activity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AddActivityTask(TActivity activity, TaskDTO task, int order)
        {
            throw new NotImplementedException();
        }
    }

}
