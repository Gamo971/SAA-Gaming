package com.starpanel.app.config

object NetworkConfig {
    const val DEFAULT_WEBSOCKET_PORT = 8765
    const val DEFAULT_UDP_PORT = 8766
    const val WEBSOCKET_PATH = "/starpanel"
    const val MDNS_SERVICE_TYPE = "_starpanel._tcp.local"
    const val CONNECTION_TIMEOUT_MS = 5000L
    const val RECONNECT_DELAY_MS = 2000L
}
