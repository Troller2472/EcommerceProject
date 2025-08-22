﻿using Ecommerce.Commons.Interfaces;
using Microsoft.JSInterop;
using System.Text.Json;

namespace Ecommerce.Commons.LocalStorage
{
    public class LocalStorageServices : ILocalStorageService
    {
        private readonly IJSRuntime _jsRuntime;

        public LocalStorageServices(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task SetItemAsync<T>(string key, T value)
        {
            var json = JsonSerializer.Serialize(value);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", key, json);
        }

        public async Task<T> GetItemAsync<T>(string key)
        {
            var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", key);
            return json == null ? default : JsonSerializer.Deserialize<T>(json);
        }

        public async Task RemoveItemAsync(string key)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
        }

        public async Task<bool> ExistsAsync(string key)
        {
            var value = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", key);
            return value != null;
        }
    }
}

