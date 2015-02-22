﻿using System;

namespace SharpBgfx {
    /// <summary>
    /// Represents a dynamically updateable vertex buffer.
    /// </summary>
    public unsafe struct DynamicVertexBuffer : IDisposable, IEquatable<DynamicVertexBuffer> {
        internal ushort handle;

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicVertexBuffer"/> struct.
        /// </summary>
        /// <param name="vertexCount">The number of vertices that fit in the buffer.</param>
        /// <param name="layout">The layout of the vertex data.</param>
        public DynamicVertexBuffer (int vertexCount, VertexLayout layout) {
            handle = NativeMethods.bgfx_create_dynamic_vertex_buffer(vertexCount, ref layout.data, 0);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicVertexBuffer"/> struct.
        /// </summary>
        /// <param name="memory">The initial vertex data with which to populate the buffer.</param>
        /// <param name="layout">The layout of the vertex data.</param>
        public DynamicVertexBuffer (MemoryBlock memory, VertexLayout layout) {
            handle = NativeMethods.bgfx_create_dynamic_vertex_buffer_mem(memory.ptr, ref layout.data);
        }

        /// <summary>
        /// Updates the data in the buffer.
        /// </summary>
        /// <param name="memory">The new vertex data with which to fill the buffer.</param>
        public void Update (MemoryBlock memory) {
            NativeMethods.bgfx_update_dynamic_vertex_buffer(handle, memory.ptr);
        }

        /// <summary>
        /// Releases the vertex buffer.
        /// </summary>
        public void Dispose () {
            NativeMethods.bgfx_destroy_dynamic_vertex_buffer(handle);
        }

        /// <summary>
        /// Determines whether the specified object is equal to this instance.
        /// </summary>
        /// <param name="other">The object to compare with this instance.</param>
        /// <returns><c>true</c> if the specified object is equal to this instance; otherwise, <c>false</c>.</returns>
        public bool Equals (DynamicVertexBuffer other) {
            return handle == other.handle;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals (object obj) {
            var other = obj as DynamicVertexBuffer?;
            if (other == null)
                return false;

            return Equals(other);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode () {
            return handle.GetHashCode();
        }

        /// <summary>
        /// Implements the equality operator.
        /// </summary>
        /// <param name="left">The left side of the operator.</param>
        /// <param name="right">The right side of the operator.</param>
        /// <returns>
        /// <c>true</c> if the two objects are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(DynamicVertexBuffer left, DynamicVertexBuffer right) {
            return left.Equals(right);
        }

        /// <summary>
        /// Implements the inequality operator.
        /// </summary>
        /// <param name="left">The left side of the operator.</param>
        /// <param name="right">The right side of the operator.</param>
        /// <returns>
        /// <c>true</c> if the two objects are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(DynamicVertexBuffer left, DynamicVertexBuffer right) {
            return !left.Equals(right);
        }
    }
}
