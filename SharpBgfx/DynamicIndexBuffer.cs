﻿using System;

namespace SharpBgfx {
    /// <summary>
    /// Represents a dynamically updateable index buffer.
    /// </summary>
    /// <remarks>Indices are always 16-bits.</remarks>
    public unsafe struct DynamicIndexBuffer : IDisposable, IEquatable<DynamicIndexBuffer> {
        internal ushort handle;

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicIndexBuffer"/> struct.
        /// </summary>
        /// <param name="indexCount">The number of indices that can fit in the buffer.</param>
        public DynamicIndexBuffer (int indexCount) {
            handle = NativeMethods.bgfx_create_dynamic_index_buffer(indexCount);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicIndexBuffer"/> struct.
        /// </summary>
        /// <param name="memory">The initial index data with which to populate the buffer.</param>
        public DynamicIndexBuffer (MemoryBlock memory) {
            handle = NativeMethods.bgfx_create_dynamic_index_buffer_mem(memory.ptr);
        }

        /// <summary>
        /// Updates the data in the buffer.
        /// </summary>
        /// <param name="memory">The new index data with which to fill the buffer.</param>
        public void Update (MemoryBlock memory) {
            NativeMethods.bgfx_update_dynamic_index_buffer(handle, memory.ptr);
        }

        /// <summary>
        /// Releases the index buffer.
        /// </summary>
        public void Dispose () {
            NativeMethods.bgfx_destroy_dynamic_index_buffer(handle);
        }

        /// <summary>
        /// Determines whether the specified object is equal to this instance.
        /// </summary>
        /// <param name="other">The object to compare with this instance.</param>
        /// <returns><c>true</c> if the specified object is equal to this instance; otherwise, <c>false</c>.</returns>
        public bool Equals (DynamicIndexBuffer other) {
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
            var other = obj as DynamicIndexBuffer?;
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
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString () => $"Handle: {handle}";

        /// <summary>
        /// Implements the equality operator.
        /// </summary>
        /// <param name="left">The left side of the operator.</param>
        /// <param name="right">The right side of the operator.</param>
        /// <returns>
        /// <c>true</c> if the two objects are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(DynamicIndexBuffer left, DynamicIndexBuffer right) {
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
        public static bool operator !=(DynamicIndexBuffer left, DynamicIndexBuffer right) {
            return !left.Equals(right);
        }
    }
}
