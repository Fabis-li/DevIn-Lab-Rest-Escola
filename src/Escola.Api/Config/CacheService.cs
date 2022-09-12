using Microsoft.Extensions.Caching.Memory;

namespace Escola.Api.Config
{
    public class CacheService<TEntity>
    {
        private readonly IMemoryCache _cache;
        private string _baseKey;
        private TimeSpan _expiracao;
        public CacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void Config(string baseKey,TimeSpan expiracao){
            _baseKey = baseKey;
            _expiracao = expiracao;
        }

        public TEntity Set(string paramentro, TEntity entity){
            return _cache.Set<TEntity>(MontarChave(paramentro), entity, _expiracao);
        }
        public bool TryGetValue(string paramentro, out TEntity entity){
            return _cache.TryGetValue<TEntity>(MontarChave(paramentro), out entity);
        }

        public void Remove (string paramentro){
            _cache.Remove(MontarChave(paramentro));
        }

        private string MontarChave(string paramentro){
            return $"{_baseKey}:{paramentro}";
        }
    }
}