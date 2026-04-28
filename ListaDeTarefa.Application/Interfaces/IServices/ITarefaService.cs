using ListaDeTarefa.Application.DTOs.Tarefa;
using ListaDeTarefa.Domain.Entities;

namespace ListaDeTarefa.Application.Interfaces.IServices
{
	public interface ITarefaService
	{
		Task<IEnumerable<TarefaDto>> BuscarTodos();
		Task<TarefaDto?> BuscarPorId(Guid id);
		Task<TarefaDto> Adicionar(TarefaCreateDto createDto);
		Task Atualizar(Guid id, TarefaUpdateDto updateDto);
		Task Remover(Guid id);

		Task<TarefaDto?> BuscarPorDescricao(string descricao);
	}
}
